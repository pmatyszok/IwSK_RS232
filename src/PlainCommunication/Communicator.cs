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

        private readonly Parser _parser;
        private readonly SerialPort _port;

        //just a convienient hack to avoid multiple checking of action presence
        public Action<bool> CDCLineChanged = obj => { };
        public Action<bool> CTSLineChanged = obj => { };
        public Action<bool> DSRLineChanged = obj => { };
        public Action<bool> DTRLineChanged = obj => { };
        public Action<bool> RTSLineChanged = obj => { };

        private bool DTRState;
        private bool RTSState;

        public Action<string> MessageOccured;
        public Action RingIndicatorChanged = () => { };
        private long _pingMilliseconds;

        public Communicator(string which, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake hand,
            string newline)
        {
            _port = new SerialPort(which, baudRate, parity, dataBits, stopBits) {Handshake = hand, NewLine = newline};
            _port.Open();
            _port.DataReceived += port_DataReceived;
            _port.PinChanged += port_PinChanged;

            _parser = new Parser(newline);

            _parser.CommandRecognized += CommandRecognized;
        }

        public bool HexTrans { get; set; }

        public void Dispose()
        {
            if (_port.IsOpen)
                _port.Dispose();
        }


        private void port_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            switch (e.EventType)
            {
                case SerialPinChange.Break:
                    //dunno what to do
                    break;
                case SerialPinChange.CDChanged:
                    CDCLineChanged(_port.CDHolding);
                    break;
                case SerialPinChange.CtsChanged:
                    CTSLineChanged(_port.CtsHolding);
                    break;
                case SerialPinChange.DsrChanged:
                    DSRLineChanged(_port.DsrHolding);
                    break;
                case SerialPinChange.Ring:
                    RingIndicatorChanged();
                    break;
            }

            if (RTSState != _port.RtsEnable)
            {
                RTSLineChanged(_port.RtsEnable);
                RTSState = _port.RtsEnable;
            }

            if (DTRState != _port.DtrEnable)
            {
                DTRLineChanged(_port.DtrEnable);
                DTRState = _port.DtrEnable;
            }
        }

        public void SendString(string msg)
        {
            _port.WriteLine(msg);
        }

        public void SendPing()
        {
            const string ping = "ping";
            _pingMilliseconds = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;
            _port.WriteLine(ping);
        }

        public void SendPong()
        {
            const string pong = "pong";
            MessageOccured(pong);
            _port.WriteLine(pong);
        }

        private void CommandRecognized()
        {
            while (_parser.HasNextCommand())
            {
                string cmd;
                _parser.GetNextCommand(out cmd);
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
                            _pingMilliseconds = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond - _pingMilliseconds;
                            MessageOccured("Ping OK time = " + _pingMilliseconds + "ms");
                        }
                        else
                        {
                            if (!HexTrans)
                            {
                                MessageOccured(cmd);
                            }
                            else
                            {
                                byte[] decByte3 = Convert.FromBase64String(cmd);
                                string msg = "";
                                foreach (byte b in decByte3)
                                {
                                    msg += b.ToString("X");
                                }
                                MessageOccured(msg);
                            }
                        }
                    }
                }
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = (SerialPort) sender;
            _parser.Append(sp.ReadExisting());
        }

        public void SetSerialPortData(int data)
        {
            _port.DataBits = data;
        }

        public static List<string> GetPorts()
        {
            List<string> ports = SerialPort.GetPortNames().ToList();
            ports.Sort();
            return ports;
        }
    }
}