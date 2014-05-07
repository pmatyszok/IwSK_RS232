using System;
using System.Linq;
using System.Windows.Forms;
using IwSK_RS232.PlainCommunication;
using IwSK_RS232.Properties;
using IwSK_RS232.Tools;
using System.IO.Ports;

namespace IwSK_RS232
{
    public partial class MainForm : Form
    {
        #region fields

        private Communicator com = null;
        private readonly int[] BaundRate = { 75, 150, 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 };
        private readonly int[] DataBit = { 5, 6, 7, 8, 9 };
        enum NewLine { CR = 0, CRLF = 1, LF = 2, None = 3 };
        private readonly string[] newLine = { "\n", "\r\n", "\r", "" };
        private bool customLine;
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
                //TODO przypisanie obsluia zdarzenia otrzymania wiadomosci dla modbusa
                tabControl1.SelectTab(1);
              
                

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
            string toSend = sendtext.Text;
            Log.Append(toSend);
            com.SendString(toSend);
            sendtext.Clear();
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
    }
}
