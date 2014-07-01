using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace IwSK_RS232.PlainCommunication
{
    internal class Communicator : IDisposable
    {
        [Flags]
        public enum Pins
        {
            DCD = 0x01,
            RI =  0x02,
            DSR = 0x04,
            CTS = 0x08,
            RTS = 0x10,
            DTR = 0x20
        }

        private readonly Parser parser;
        private readonly SerialPort port;

        public Action<string> MessageOccured;
        public Action DataReceived;

        private long pingMilliseconds;

        public Communicator(string which, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake hand,
            string newline,bool custom)
        {
           
            port = new SerialPort(which, baudRate, parity, dataBits, stopBits) { Handshake = hand, NewLine = newline };
            port.ReadTimeout = 500;
            port.WriteTimeout = 500;
            port.Open();
            port.DataReceived += port_DataReceived;
            if (!newline.Equals("None") && !newline.Equals("No Auto"))
            {
                parser = new Parser(newline,custom);
            }
            else
            {
                if (newline.Equals("None"))
                    parser = new Parser("",false);
                if (newline.Equals("No Auto"))
                    parser = new Parser(new string(new char[]{'\\','r'}),true);  
            }

            parser.CommandRecognized += CommandRecognized;
        }

        public bool HexTrans { get; set; }

        public void Dispose()
        {
            if (port.IsOpen)
                port.Dispose();
        }

        public void SendString(string msg)
        {
            try
            {
                if (this.port.NewLine.Equals("None") || this.port.NewLine.Equals("No Auto"))
                    port.Write(msg);
                else
                    port.WriteLine(msg);
                
            }
            catch (Exception)
            {
            }
        }


        public void SendPing()
        {
            try
            {
                const string ping = "ping";
                pingMilliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                port.WriteLine(ping);
            }
            catch (Exception)
            { }
        }

        public void SendPong()
        {
            const string pong = "pong";
            MessageOccured(pong);
            port.WriteLine(pong);
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
                    {
                        if (cmd.Equals("ping"))
                        {
                            SendPong();
                        }
                        else if (cmd.Equals("pong"))
                        {
                            pingMilliseconds = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond - pingMilliseconds;
                            MessageOccured("Ping OK time = " + pingMilliseconds + "ms");
                        }
                        else
                        {
                            if (!HexTrans)
                            {
                                MessageOccured(cmd);
                            }
                            else
                            {
                                try
                                {
                                    byte[] decByte3 = Convert.FromBase64String(cmd);
                                    string msg = "";
                                    foreach (byte b in decByte3)
                                    {
                                        msg += b.ToString("X");
                                    }
                                    MessageOccured(msg);
                                }
                                catch (SystemException ex)
                                {
                                    MessageOccured(ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = (SerialPort) sender;
            if (DataReceived != null) 
                DataReceived();
            parser.Append(sp.ReadExisting());
        }

        public void SetSerialPortData(int data)
        {
            port.DataBits = data;
        }

        public void setNewLine(string line)
        {
            port.NewLine = line;
        }

        public static List<string> GetPorts()
        {
            List<string> ports = SerialPort.GetPortNames().ToList();
            ports.Sort();
            return ports;
        }
    }
}