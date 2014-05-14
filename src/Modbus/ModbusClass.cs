﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;

namespace IwSK_RS232.Modbus
{
    internal class ModbusClass
    {
        private readonly ConcurrentQueue<string> _receivedFrames = new ConcurrentQueue<string>();
        public Action<string> FrameRecieved;
        public Action<string> TextRecieved;
        public Action<string> SendFrame;
        private bool _isMaster;
        private string _recievedText;
        private byte _stationAddress;
        private byte _lastFrameDestinationAddress;

        public void RecievedFrame(string frame)
        {
            _receivedFrames.Enqueue(frame);
            FrameRecieved(frame);
            if (CheckLRC(frame))
            {
                if (!_isMaster)
                {
                    byte recievedAdress = ASCIIcodeToByte(frame.Substring(1, 2));
                    byte command = ASCIIcodeToByte(frame.Substring(3, 2));
                    if (_stationAddress == recievedAdress)
                    {
                        switch (command)
                        {
                            case 0x01:
                                {
                                    _recievedText = ASCIIcodeStringToString(frame.Substring(5, frame.Length - 9));
                                    TextRecieved(_recievedText);
                                    break;
                                }
                            case 0x02:
                                {
                                    string frameToSend = this.MakeFrameToSend(recievedAdress, command, _recievedText);
                                    SendFrame(frameToSend);
                                    break;
                                }
                        }
                    }
                    else if (recievedAdress == 0 && command == 1)
                    {
                        _recievedText = ASCIIcodeStringToString(frame.Substring(5, frame.Length - 9));
                        TextRecieved(_recievedText);
                    }
                }
                else
                {
                    byte recievedAdress = ASCIIcodeToByte(frame.Substring(1, 2));
                    byte command = ASCIIcodeToByte(frame.Substring(3, 2));
                    if (recievedAdress == _lastFrameDestinationAddress && command == 0x02 && CheckLRC(frame))
                    {
                        string recieText = ASCIIcodeStringToString(frame.Substring(5, frame.Length - 9));
                        TextRecieved(recieText);
                    }

                }
            }
        }

        public void SetMaster()
        {
            _isMaster = true;
        }

        public void SetSlave()
        {
            _isMaster = false;
        }

        public void SetAddress(byte address)
        {
            if (!_isMaster)
                _stationAddress = address;
        }

        private byte generateLRC(string data)
        {
            byte sum = 0;
            int i;
            for (i = 0; i < data.Length; i++)
                sum += (byte) data[i];
            return (byte) (~sum + 1);
        }

        private byte ASCIIcodeToByte(string data)
        {
            byte result = 0;
            int i, temp = 0;
            for (i = 0; i < data.Length; i++)
            {
                if (data[i] >= 'A' && data[i] <= 'F')
                {
                    temp = Convert.ToInt16(data[i]) - 55;
                }
                if (data[i] >= '0' && data[i] <= '9')
                {
                    temp = Convert.ToInt16(data[i]) - 48;
                }
                if (i == 0)
                {
                    result += Convert.ToByte(temp << 4);
                }
                else if (i == 1)
                {
                    result += Convert.ToByte(temp);
                }
            }
            return result;
        }

        public string ByteToASCIIcode(byte data)
        {
            string result = "";
            char tmp = ' ';

            int temp = data & 0xF0;
            temp = temp >> 4;

            if (temp >= 10 && temp <= 15)
            {
                tmp = Convert.ToChar(temp + 55);
            }
            if (temp >= 0 && temp <= 9)
            {
                tmp = Convert.ToChar(temp + 48);
            }

            result += tmp.ToString();


            temp = data & 0x0F;

            if (temp >= 10 && temp <= 15)
            {
                tmp = Convert.ToChar(temp + 55);
            }
            if (temp >= 0 && temp <= 9)
            {
                tmp = Convert.ToChar(temp + 48);
            }

            result += tmp.ToString();
            return result;
        }

        private string ASCIIcodeStringToString(string data)
        {
            string tmp = "";
            for (int i = 0; i < data.Length - 1; i = i + 2)
            {
                tmp += (char) ASCIIcodeToByte(data.Substring(i, 2));
            }
            return tmp;
        }

        private bool CheckLRC(string frame)
        {
            //TODO  funkcja sprawdzajaca poprawnosc przeslania ramki
            if (frame == null || frame[0] != ':')
                return false;
            string srcForLRC = frame.Substring(1, frame.Length - 5);
            byte receivedLRC = ASCIIcodeToByte(frame.Substring(frame.Length - 4, 2));
            if (receivedLRC == generateLRC(srcForLRC))
                return true;
            return false;
        }

        public string MakeFrameToSend(byte adres, byte command, string args)
        {
            if (command == 0x02 && args == null)
                _lastFrameDestinationAddress = adres;
            string frame = ":";
            frame += ByteToASCIIcode(adres) + ByteToASCIIcode(command);
            if(args!=null)
                for (int i = 0; i < args.Length; i++)
                    frame += ByteToASCIIcode((byte) args[i]);
            byte lrcSum = generateLRC(frame.Substring(1));
            frame += ByteToASCIIcode(lrcSum);
            return frame;
        }
    }
}