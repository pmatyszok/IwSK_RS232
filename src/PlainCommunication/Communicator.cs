using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;

namespace IwSK_RS232.PlainCommunication
{
    class Communicator : IDisposable
    {
        [Flags]
        public enum Pins
        {
            DCD =   0x01,
            RI  =   0x02,
            DSR =   0x04,
            CTS =   0x08,
            RTS =   0x10,
            DTR =   0x20
        }

        private bool RTSState;
        private bool DTRState;

        private SerialPort port;
        private readonly Parser parser = new Parser();
     

        public Action<string> MessageOccured;
        //just a convienient hack to avoid multiple checking of action presence
        public Action RingIndicatorChanged = () => { };
        public Action<bool> CDCLineChanged = obj => { };
        public Action<bool> CTSLineChanged = obj => { };
        public Action<bool> DSRLineChanged = obj => { };
        public Action<bool> RTSLineChanged = obj => { };
        public Action<bool> DTRLineChanged = obj => { };

        public Communicator(string which,int baudRate,Parity parity, int dataBits, StopBits stopBits,Handshake hand,string newline )
        {
            port = new SerialPort(which, baudRate, parity, dataBits, stopBits) {Handshake = hand, NewLine = newline};
            port.Open();
            port.DataReceived += port_DataReceived;
            port.PinChanged += port_PinChanged;

            parser.CommandRecognized += CommandRecognized;
        }



        void port_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            switch (e.EventType)
            {
                case SerialPinChange.Break:
                    //dunno what to do
                    break;
                case SerialPinChange.CDChanged:
                    CDCLineChanged(port.CDHolding);
                    break;
                case SerialPinChange.CtsChanged:
                    CTSLineChanged(port.CtsHolding);
                    break;
                case SerialPinChange.DsrChanged:
                    DSRLineChanged(port.DsrHolding);
                    break;
                case SerialPinChange.Ring:
                    RingIndicatorChanged();
                    break;
            }

            if (RTSState != port.RtsEnable)
            {
                RTSLineChanged(port.RtsEnable);
                RTSState = port.RtsEnable;
            }

            if (DTRState != port.DtrEnable)
            {
                DTRLineChanged(port.DtrEnable);
                DTRState = port.DtrEnable;
            }
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
