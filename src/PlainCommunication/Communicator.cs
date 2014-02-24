using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using IwSK_RS232.PlainCommunication;

namespace IwSK_RS232
{
    class Communicator : IDisposable
    {
        private SerialPort port;
        private readonly Parser parser = new Parser();


        public Action<string> MessageOccured;

        public Communicator(string which)
        {
            port = new SerialPort(which)
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.Two,
                Parity = Parity.None,
                NewLine = "\r\n"
            };
            port.Open();
            port.DataReceived += port_DataReceived;

            parser.CommandRecognized += CommandRecognized;
        }

        public void SendString(string msg)
        {
            port.WriteLine(msg);
        }

        private void CommandRecognized()
        {
            while (parser.HasNextCommand())
            {
                string cmd;
                parser.GetNextCommand(out cmd);
                if (!string.IsNullOrEmpty(cmd))
                {
                    if (MessageOccured != null)
                        MessageOccured(cmd);
                    cmd = string.Empty;
                }
            }
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort) sender;
            parser.Append(sp.ReadExisting());
        }

        public void Dispose()
        {
            if (port.IsOpen)
                port.Dispose();
        }

        public static List<string> GetPorts()
        {
            return SerialPort.GetPortNames().ToList();
        }
    }
}
