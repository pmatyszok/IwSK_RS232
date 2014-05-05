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
        private int[] BaundRate = { 75, 110, 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 };
        private int[] DataBit = { 5, 6, 7, 8, 9 };
        enum NewLine {CR=0,CRLF=1};
        private string[] newLine = { "\n", "\r\n" };
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
            foreach (var panel in this.Controls.OfType<Panel>())
            {
                foreach (var item in panel.Controls.OfType<RadioButton>())
                {
                    item.Enabled = false;
                }    
            }
            
            
            
        }

        private void refreshComListBtn_Click(object sender, EventArgs e)
        {
            comPortsCombo.Items.Clear();
            comPortsCombo.Items.AddRange(Communicator.GetPorts().ToArray());
        }

        private void ATBtn_Click(object sender, EventArgs e)
        {
            string at = "AT";
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
                
                NewLine line;
                Enum.TryParse<NewLine>(newLineCombo.SelectedValue.ToString(),out line);
                
                com = new Communicator(name, 
                    (int)baudRateCombo.SelectedValue, 
                    parity,
                    (int)dataBitsCombo.SelectedValue, 
                    stopbit,
                    hand, 
                    newLine[(int)line]);

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

            if (com != null)
            {
                ChangeControlsEnable(true);
                com.MessageOccured += Log.Append;
            }
        }

        /// <summary>
        /// Sets critical to communication controls to given state
        /// </summary>
        private void ChangeControlsEnable(bool state)
        {
            
            userConsole.Enabled = state;
            ATBtn.Enabled = state;
        }

        #endregion //methods

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (com != null)
                com.Dispose();
        }
    }
}
