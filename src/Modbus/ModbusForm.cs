using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using IwSK_RS232.PlainCommunication;

namespace IwSK_RS232.Modbus
{
    public partial class ModbusForm : Form
    {
        static private Communicator communicator;
        public ModbusForm(string name, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake hand, string newline)
        {
            
            InitializeComponent();
            communicator = new Communicator(name,
                    baudRate,
                    parity,
                    dataBits,
                    stopBits,
                    hand,
                    newline);
            communicator.MessageOccured += newFrame;
            
        }

        private void newFrame(string obj)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void masterSlaveComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if ("Master" == masterSlaveComboBox.SelectedItem.ToString())
            {
                masterPanel.Visible = true;
            }
            else
                masterPanel.Visible = false;
        }

        private void masterSlaveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
