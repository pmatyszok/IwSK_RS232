using System;
using System.Windows.Forms;
using IwSK_RS232.PlainCommunication;
using IwSK_RS232.Properties;
using IwSK_RS232.Tools;

namespace IwSK_RS232
{
    public partial class MainForm : Form
    {
        #region fields

        private Communicator com = null;

        #endregion //fields

        #region methods
        
        public MainForm()
        {
            InitializeComponent();
            ChangeControlsEnable(false);
            Log.Console = userConsole;
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
                com = new Communicator(name);
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
