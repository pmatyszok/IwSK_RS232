using System;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using IwSK_RS232.Modbus;
using IwSK_RS232.PlainCommunication;
using IwSK_RS232.Properties;
using IwSK_RS232.Tools;
using System.Runtime.InteropServices;

namespace IwSK_RS232
{
    public partial class MainForm : Form
    {
        #region fields

        private readonly int[] _baundRate = {75, 150, 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200};
        private readonly int[] _dataBit = {5, 6, 7, 8, 9};

        private readonly string[] _newLine = {"\n", "\r\n", "\r"};
        private Communicator port;
        private bool _customLine;
        private bool _hexTransmission;
        private ModbusClass _modbus;

        private enum NewLine
        {
            CR = 0,
            CRLF = 1,
            LF = 2
        };

        #endregion //fields

        public MainForm()
        {
            InitializeComponent();
            ChangeControlsEnable(false);
            Log.Console = userConsole;

            parityCombo.DataSource = Enum.GetNames(typeof(Parity));
            stopSignCombo.DataSource = Enum.GetNames(typeof(StopBits));
            stopSignCombo.SelectedIndex = 1;
            handShakeCombo.DataSource = Enum.GetNames(typeof(Handshake));
            newLineCombo.DataSource = Enum.GetNames(typeof(NewLine));
            baudRateCombo.DataSource = _baundRate;
            dataBitsCombo.DataSource = _dataBit;
            customlinetext.MaxLength = 2;
            customlinetext.Enabled = false;
            hextext.Enabled = false;
            FileButton.Enabled = false;
            SendFile.Enabled = false;
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                foreach (RadioButton item in panel.Controls.OfType<RadioButton>())
                {
                    item.Enabled = false;
                }
            }

            RefreshPorts();
        }

        #region API Stuff
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("user32.dll")]
        private static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);

        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;

        public int HorizontalPosition(RichTextBox box)
        {
            return GetScrollPos((IntPtr)box.Handle, SB_VERT);
        }

        public bool IsAtMaxScroll(RichTextBox box)
        {
            int minScroll, maxScroll;

            GetScrollRange(box.Handle, SB_VERT, out minScroll, out maxScroll);
            int i = HorizontalPosition(box) + box.ClientSize.Height;
            return (HorizontalPosition(box) + box.ClientSize.Height >= (maxScroll - 15));
        }
        #endregion


        #region methods

        private void RefreshPorts()
        {
            comPortsCombo.Items.Clear();
            comPortsCombo.SelectedIndex = -1;

            foreach (string port in Communicator.GetPorts().Where(port => port.StartsWith("COM")))
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
            RefreshPorts();
        }

        private void ATBtn_Click(object sender, EventArgs e)
        {
            const string at = "AT";
            Log.Append(at);
            port.SendString(at);
        }

        private void selectPortButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string) comPortsCombo.SelectedItem))
                return;

            var name = (string) comPortsCombo.SelectedItem;
            if (port != null)
            {
                port.Dispose();
                port = null;
            }

            try
            {
                Parity parity;
                Enum.TryParse(parityCombo.SelectedValue.ToString(), out parity);

                StopBits stopbit;
                Enum.TryParse(stopSignCombo.SelectedValue.ToString(), out stopbit);

                Handshake hand;
                Enum.TryParse(handShakeCombo.SelectedValue.ToString(), out hand);


                string terminator;
                if (!_customLine)
                {
                    NewLine line;
                    Enum.TryParse(newLineCombo.SelectedValue.ToString(), out line);
                    terminator = _newLine[(int) line];
                }
                else
                {
                    terminator = customlinetext.Text;
                }


                port = new Communicator(name,
                    (int) baudRateCombo.SelectedValue,
                    parity,
                    (int) dataBitsCombo.SelectedValue,
                    stopbit,
                    hand,
                    terminator);
            }
            catch (Exception ex)
            {
                string warn = Resources.errorDuringSerialPortCreation__ + Environment.NewLine + ex.Message;
                Log.Append(warn);
                MessageBox.Show(Resources.errorDuringSerialPortCreation__ + Environment.NewLine + ex.Message);
            }

            if (port != null && !modBusCheckBox.Checked)
            {
                ChangeControlsEnable(true);
                port.MessageOccured += Log.Append;
            }
            else if (modBusCheckBox.Checked)

            {
                ChangeControlsEnable(true);
                _modbus = new ModbusClass();
                _modbus.FrameRecieved += AddRecievedFrameToModbusLog;
                if (port != null)
                {
                    port.MessageOccured += _modbus.RecievedFrame;
                    port.DataReceived += _modbus.CheckInterval;
                }
                _modbus.TextRecieved += AddRecievedTextToTextRecievedBox;
                _modbus.SendFrame += SendModbusFrame;
                _modbus.SetAddress((byte)adressNumericUpDown.Value);
                _modbus.SetTimeoutTime((int)transactionTimeoutNumericUpDown.Value);
                _modbus.SetAmountOfRetransmissions((int)amountOfRetransmNumUpDown.Value);
                _modbus.Interval = (int)frameTimeoutNumericUpDown.Value;
                tabControl1.SelectTab(1);
                if (MasterRadioButton.Checked)
                    _modbus.SetMaster();
                else
                    _modbus.SetSlave();
            }
        }

        /// <summary>
        ///     Sets critical to communication controls to given state
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null)
                port.Dispose();
        }

        private void customnewline_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!_customLine)
            {
                newLineCombo.Enabled = false;
                customlinetext.Enabled = true;
            }
            else
            {
                newLineCombo.Enabled = true;
                customlinetext.Enabled = false;
            }
            _customLine = !_customLine;
        }

        private void sendbutton_Click_1(object sender, EventArgs e)
        {
            string toSend;
            if (!_hexTransmission)
            {
                toSend = sendtext.Text;
                Log.Append(toSend);
                port.SendString(toSend);
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
                port.SendString(send);
                hextext.Clear();
            }
        }

        private void modBusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (modBusCheckBox.Checked)
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
            port.SendPing();
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
                messageModbusTextBox.Show();
                messageModbusTextBox.Visible = ((byte)commandNumericUpDown.Value) != 0x02;
                messageLabel.Visible = messageModbusTextBox.Visible;
                receiverAddressLabel.Text = "Receiver address:";
                adressNumericUpDown.Minimum = 0;
                if (_modbus != null)
                    _modbus.SetMaster();
            }
            else if (SlaveRadioButton.Checked)
            {
                timeoutLabel.Hide();
                transactionTimeoutNumericUpDown.Hide();
                commandLabel.Hide();
                commandNumericUpDown.Hide();
                amountOfRetransLabel.Hide();
                amountOfRetransmNumUpDown.Hide();
                messageModbusTextBox.Hide();
                sendModbusButton.Hide();
                messageLabel.Hide();
                receiverAddressLabel.Text = "Station address:";
                adressNumericUpDown.Minimum = 1;
                if (_modbus != null)
                {
                    _modbus.SetSlave();
                    _modbus.SetAddress((byte)adressNumericUpDown.Value);
                }
            }
        }

        private void adressNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_modbus != null)
            {
                _modbus.SetAddress((byte)adressNumericUpDown.Value);
            }
        }

        private void hexSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (!_hexTransmission)
            {
                sendtext.Enabled = false;
                hextext.Enabled = true;
                port.SetSerialPortData(8);
                dataBitsCombo.SelectedIndex = 3;
                dataBitsCombo.Enabled = false;
                _hexTransmission = true;
                port.HexTrans = true;
                ATBtn.Enabled = false;
                PINGBtn.Enabled = false;
                FileButton.Enabled = true;
                SendFile.Enabled = true;
            }
            else
            {
                sendtext.Enabled = true;
                hextext.Enabled = false;
                _hexTransmission = false;
                dataBitsCombo.Enabled = true;
                port.HexTrans = false;
                ATBtn.Enabled = true;
                PINGBtn.Enabled = true;
                FileButton.Enabled = false;
                SendFile.Enabled = false;
            }
        }

        private void hextext_TextChanged(object sender, EventArgs e)
        {
            string item = hextext.Text;
            string toParse = "";
            if (item.Length != 0)
                toParse = item[item.Length - 1].ToString();
            int n = 0;
            if (!int.TryParse(toParse, NumberStyles.HexNumber, NumberFormatInfo.CurrentInfo, out n) &&
                item != String.Empty)
            {
                hextext.Text = item.Remove(item.Length - 1, 1);
                hextext.SelectionStart = hextext.Text.Length;
            }
        }

        private void FileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = hexFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                filebox.Text = hexFile.FileName;
            }
        }

        private void SendFile_Click(object sender, EventArgs e)
        {
            if (!filebox.Text.Equals(""))
            {
                try
                {
                    byte[] toSend = File.ReadAllBytes(filebox.Text);
                    string send = Convert.ToBase64String(toSend);
                    port.SendString(send);
                    string toLog = "";
                    foreach (byte b in toSend)
                    {
                        toLog += b.ToString("X");
                    }
                    Log.Append(toLog);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Wybierz plik ", "Brak pliku", MessageBoxButtons.OK);
            }
        }

        private void sendModbusButton_Click(object sender, EventArgs e)
        {
            if (_modbus != null)
            {
                switch((byte)commandNumericUpDown.Value)
                {
                    case 0x01:
                        {
                                string toSend = _modbus.MakeFrameToSend((byte)adressNumericUpDown.Value,
                                (byte)commandNumericUpDown.Value, messageModbusTextBox.Text);
                                SendModbusFrame(toSend);
                                if ((byte)adressNumericUpDown.Value != 0x00)
                                    _modbus.startTimeOutCounting();
                                break;
                            
                            
                        }
                    case 0x02:
                        {
                            if ((byte)adressNumericUpDown.Value != 0x00)
                            {
                                string toSend = _modbus.MakeFrameToSend((byte)adressNumericUpDown.Value,
                                    (byte)commandNumericUpDown.Value, null);
                                SendModbusFrame(toSend);
                                _modbus.startTimeOutCounting();
                            }
                            break;
                        }
            }
            }
        }

        private void AppendNowOrLater(RichTextBox box, string text)
        {
            if (box.InvokeRequired)
                box.Invoke(new Action(() => box.AppendText(text)));
            else
                box.AppendText(text);
        }

        private void ScrollIfNeeded(RichTextBox box)
        {
            if (box.InvokeRequired)
            {
                box.Invoke(new Action(() => ScrollIfNeeded(box)));
            }
            else
            {
                if (IsAtMaxScroll(box))
                {
                    box.SelectionStart = box.Text.Length;
                    box.ScrollToCaret();
                }
            }
        }

        private void AddRecievedFrameToModbusLog(string frame)
        {
            AppendNowOrLater(IncomingRichTextBox,"0x");
            for (int i = 0; i < frame.Length; i++)
                AppendNowOrLater(IncomingRichTextBox, _modbus.ByteToASCIIcode((byte)frame[i]));
            AppendNowOrLater(IncomingRichTextBox,"\n");
            ScrollIfNeeded(IncomingRichTextBox);
        }

        private void AddRecievedTextToTextRecievedBox(string text)
        {
            AppendNowOrLater(ReceivedTextRichBox, text + '\n');
            ScrollIfNeeded(ReceivedTextRichBox);
        }

        private void SendModbusFrame(string toSend)
        {
            port.SendString(toSend);
            AppendNowOrLater(outcomingRichTextBox,"0x");
            for (int i = 0; i < toSend.Length; i++)
                AppendNowOrLater(outcomingRichTextBox,_modbus.ByteToASCIIcode((byte)toSend[i]));
            AppendNowOrLater(outcomingRichTextBox,_modbus.ByteToASCIIcode((byte)'\r'));
            AppendNowOrLater(outcomingRichTextBox,_modbus.ByteToASCIIcode((byte)'\n') + "\n");
            ScrollIfNeeded(outcomingRichTextBox);
        }
        #endregion //methods

        private void transactionTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_modbus != null)
            {
                _modbus.SetTimeoutTime((int)transactionTimeoutNumericUpDown.Value);
            }
        }

        private void amountOfRetransmNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(_modbus!=null)
                _modbus.SetAmountOfRetransmissions((int)amountOfRetransmNumUpDown.Value);
        }

        private void frameTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _modbus.Interval = (int)frameTimeoutNumericUpDown.Value;
        }

        private void commandNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            messageModbusTextBox.Visible = ((byte)commandNumericUpDown.Value) != 0x02;
            messageLabel.Visible = messageModbusTextBox.Visible;
        }
       
    }
}