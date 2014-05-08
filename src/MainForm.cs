using System;
using System.Linq;
using System.Windows.Forms;
using IwSK_RS232.Modbus;
using IwSK_RS232.PlainCommunication;
using IwSK_RS232.Properties;
using IwSK_RS232.Tools;

using System.IO.Ports;

namespace IwSK_RS232
{
    public partial class MainForm : Form
    {
        #region fields
        private ModbusClass modbus = null;
        private Communicator com = null;
        private readonly int[] BaundRate = { 75, 150, 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 };
        private readonly int[] DataBit = { 5, 6, 7, 8, 9 };
        enum NewLine { CR = 0, CRLF = 1, LF = 2};
        private readonly string[] newLine = { "\n", "\r\n", "\r" };
        private bool customLine,hexTransmission;
        #endregion //fields

        #region methods
        
        public MainForm()
        {
            InitializeComponent();
            ChangeControlsEnable(false);
            Log.Console = userConsole;

            parityCombo.DataSource = Enum.GetNames(typeof(Parity));
            stopSignCombo.DataSource = Enum.GetNames(typeof(StopBits));
            stopSignCombo.SelectedIndex=1;
            handShakeCombo.DataSource = Enum.GetNames(typeof(Handshake));
            newLineCombo.DataSource = Enum.GetNames(typeof(NewLine));
            baudRateCombo.DataSource = BaundRate;
            dataBitsCombo.DataSource = DataBit;
            customlinetext.MaxLength = 2;
            customlinetext.Enabled = false;
            hextext.Enabled = false;
            foreach (var panel in this.Controls.OfType<Panel>())
            {
                foreach (var item in panel.Controls.OfType<RadioButton>())
                {
                    item.Enabled = false;
                }    
            }

            this.refreshPorts();
        }

        private void refreshPorts()
        {
            comPortsCombo.Items.Clear();
            comPortsCombo.SelectedIndex = -1;

            foreach (var port in Communicator.GetPorts().Where(port => port.StartsWith("COM")))
            {
                comPortsCombo.Items.Add(port);
            }
            
            if (comPortsCombo.Items.Count == 1)
            {
                comPortsCombo.SelectedIndex = 0;
            }
        }

        private void refreshComListBtn_Click(object sender, EventArgs e)
        {
            this.refreshPorts();
        }

        private void ATBtn_Click(object sender, EventArgs e)
        {
            const string at = "AT";
            Log.Append(at);
            com.SendString(at);
        }

        private void selectPortButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)comPortsCombo.SelectedItem))
                return;

            string name = (string)comPortsCombo.SelectedItem;
            if (com != null)
            {
                com.Dispose();
                com = null;
            }

            try
            {
                Parity parity;
                Enum.TryParse<Parity>(parityCombo.SelectedValue.ToString(), out parity);
                
                StopBits stopbit;
                Enum.TryParse<StopBits>(stopSignCombo.SelectedValue.ToString(), out stopbit);
                
                Handshake hand;
                Enum.TryParse<Handshake>(handShakeCombo.SelectedValue.ToString(), out hand);

              

                string terminator;
                if (!customLine)
                {
                    NewLine line;
                    Enum.TryParse<NewLine>(newLineCombo.SelectedValue.ToString(), out line);
                    terminator = newLine[(int)line];
                }
                else
                {
                    terminator = customlinetext.Text;
                }
               
                
                    com = new Communicator(name,
                    (int)baudRateCombo.SelectedValue,
                    parity,
                    (int)dataBitsCombo.SelectedValue,
                    stopbit,
                    hand,
                    terminator);

                    com.RingIndicatorChanged += () => RIRadio.Checked = !RIRadio.Checked;
                    com.DSRLineChanged += b => DSRRadio.Checked = b;
                    com.CTSLineChanged += b => CTSRadio.Checked = b;
                    com.CDCLineChanged += b => DCDRadio.Checked = b;
                    com.DTRLineChanged += b => DTRRadio.Checked = b;
                    com.RTSLineChanged += b => RTSRadio.Checked = b;
                
                    
            }
            catch (Exception ex)
            {
                string warn = Resources.errorDuringSerialPortCreation__ + Environment.NewLine + ex.Message;
                Log.Append(warn);
                MessageBox.Show(Resources.errorDuringSerialPortCreation__ + Environment.NewLine + ex.Message);
            }

            if (com != null && !modBusCheckBox.Checked)
            {
                ChangeControlsEnable(true);
                com.MessageOccured += Log.Append;
            }
            else if(modBusCheckBox.Checked)

            {
                ChangeControlsEnable(true);
                modbus = new ModbusClass();
                com.MessageOccured += modbus.recievedFrame;
                tabControl1.SelectTab(1);
                if (MasterRadioButton.Checked)
                    modbus.setMaster();
                else
                    modbus.setSlave();
              
                

            }
        }

        /// <summary>
        /// Sets critical to communication controls to given state
        /// </summary>
        private void ChangeControlsEnable(bool state)
        {
            userConsole.Enabled = state;
            ATBtn.Enabled = state;
            PINGBtn.Enabled = state;
            sendtext.Enabled = state;
            sendbutton.Enabled = state;
            hexSelect.Enabled = state;
        }

        #endregion //methods

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (com != null)
                com.Dispose();
        }       
        
        private void customnewline_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!customLine)
            {
                newLineCombo.Enabled = false;
                customlinetext.Enabled = true;
            }
            else
            {
                newLineCombo.Enabled = true;
                customlinetext.Enabled = false;
            }
            customLine = !customLine;
        }

        private void sendbutton_Click_1(object sender, EventArgs e)
        {
            string toSend;
            if (!hexTransmission)
            {
                toSend = sendtext.Text;
                Log.Append(toSend);
                com.SendString(toSend);
                sendtext.Clear();
            }
            else
            {
                toSend = hextext.Text;
                Log.Append(toSend);
                byte[] b;
                string tmp, tmp1;
                char[] val = toSend.ToCharArray();
                int value;
                if (toSend.Length % 2 == 0)
                {
                    int l = toSend.Length;
                    b = new byte[l / 2];
                    for (int i = 0; i < toSend.Length; i += 2)
                    {
                        tmp1 = val[i + 1].ToString();
                        tmp = val[i].ToString();
                        tmp += tmp1;
                        value = Convert.ToInt32(tmp, 16);
                        b[i / 2] = (byte)value;
                    }
                }
                else
                {
                    int l = toSend.Length;
                    b = new byte[(l / 2) + 1];
                    tmp = val[0].ToString();
                    value = Convert.ToInt32(tmp, 16);
                    b[0] = (byte)value;
                    for (int i = 1; i < toSend.Length; i += 2)
                    {
                        tmp1 = val[i + 1].ToString();
                        tmp = val[i].ToString();
                        tmp += tmp1;
                        value = Convert.ToInt32(tmp, 16);
                        b[(i / 2) + 1] = (byte)value;
                    }
                }
                string send = Convert.ToBase64String(b);
                com.SendString(send);
                hextext.Clear();
            }
        }

        private void modBusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (modBusCheckBox.Checked == true)
            {
                dataBitsCombo.Enabled = false;
                handShakeCombo.Enabled = false;
                newLineCombo.Enabled = false;
                parityCombo.Enabled = false;
                stopSignCombo.Enabled = false;

                dataBitsCombo.SelectedItem = 7;
                handShakeCombo.SelectedItem = Handshake.None.ToString();
                parityCombo.SelectedItem = Parity.None.ToString();
                stopSignCombo.SelectedItem = StopBits.Two.ToString();
                newLineCombo.SelectedItem = "CRLF";
                


                
            }
            else
            {
                dataBitsCombo.Enabled = true;
                handShakeCombo.Enabled = true;
                newLineCombo.Enabled = true;
                parityCombo.Enabled = true;
                stopSignCombo.Enabled = true;
               
            }
        }

        private void PINGBtn_Click(object sender, EventArgs e)
        {
            com.SendPing();
        }

        private void MasterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MasterRadioButton.Checked)
            {
                timeoutLabel.Show();
                transactionTimeoutNumericUpDown.Show();
                commandLabel.Show();
                commandNumericUpDown.Show();
                amountOfRetransLabel.Show();
                amountOfRetransmNumUpDown.Show();
                MessageTextBox.Show();
                sendModbusButton.Show();
                msLabel.Show();
                receiverAddressLabel.Text = "Receiver address:";
                adressNumericUpDown.Minimum = 0;
                if (modbus != null)
                    modbus.setMaster();
            }
            else
                if (SlaveRadioButton.Checked)
                {
                    timeoutLabel.Hide();
                    transactionTimeoutNumericUpDown.Hide();
                    commandLabel.Hide();
                    commandNumericUpDown.Hide();
                    amountOfRetransLabel.Hide();
                    amountOfRetransmNumUpDown.Hide();
                    MessageTextBox.Hide();
                    sendModbusButton.Hide();
                    msLabel.Hide();
                    receiverAddressLabel.Text = "Station address:";
                    adressNumericUpDown.Minimum = 1;
                    if (modbus != null)
                    {
                        modbus.setSlave();
                        modbus.setAddress((byte) adressNumericUpDown.Value);
                    }


                }
        }

        private void adressNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (modbus != null)
            {
                modbus.setAddress((byte)adressNumericUpDown.Value);
            }
        }

        private void hexSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (!hexTransmission)
            {
                sendtext.Enabled = false;
                hextext.Enabled = true;
                com.setSerialPortData(8);
                dataBitsCombo.SelectedIndex = 3;
                dataBitsCombo.Enabled = false;
                hexTransmission = true;
                com.HexTrans = true;
                ATBtn.Enabled = false;
                PINGBtn.Enabled = false;
            }
            else
            {
                sendtext.Enabled = true;
                hextext.Enabled = false;
                hexTransmission = false;
                dataBitsCombo.Enabled = true;
                com.HexTrans = false;
                ATBtn.Enabled = true;
                PINGBtn.Enabled = true;
            }
        }

        private void hextext_TextChanged(object sender, EventArgs e)
        {
            string item = hextext.Text;
            string toParse = "";
            if (item.Length != 0)
                toParse = item[item.Length - 1].ToString();
            int n = 0;
            if (!int.TryParse(toParse, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out n) &&
              item != String.Empty)
            {
                hextext.Text = item.Remove(item.Length - 1, 1);
                hextext.SelectionStart = hextext.Text.Length;
            }
        }
    }
}
