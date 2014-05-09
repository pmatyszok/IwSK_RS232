using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
namespace IwSK_RS232.Modbus
{
    
    class ModbusClass
    {
        private string recievedText;
        private byte stationAddress;
        private string frameToSend;
        private ConcurrentQueue<string> receivedFrames = new ConcurrentQueue<string>();
        private bool isMaster;
        public void recievedFrame(string frame)
        {
            receivedFrames.Enqueue(frame);
            FrameRecieved(frame);
            if (this.checkLRC(frame))
            {
                if (!isMaster)
                {
                    byte recievedAdress=ASCIIcodeToByte(frame.Substring(1,2));
                    byte command = ASCIIcodeToByte(frame.Substring(3, 2));
                    if(stationAddress==recievedAdress)
                    {
                        
                        switch (command)
                        {
                            case 0x01:{
                                recievedText = ASCIIcodeStringToString(frame.Substring(5, frame.Length - 9));
                                TextRecieved(recievedText);
                                break;
                            }
                            case 0x02:
                                {
                                    //TODO
                                    break;
                                }

                        }
                    }else
                        if (recievedAdress == 0 && command == 1)
                        {
                            recievedText = ASCIIcodeStringToString(frame.Substring(5, frame.Length - 9));
                            TextRecieved(recievedText);
                            
                        }
                }
            }

        }
        public void setMaster()
        {
            isMaster = true;
        }
        public void setSlave()
        {
            isMaster = false; 
        }
        public void setAddress(byte address)
        {
            if(!isMaster)
                stationAddress = address;
        }
        private byte generateLRC(string data)
        {
            byte sum = (byte)0;
            int i;
            for (i = 0; i < data.Length; i++)
                sum += (byte)data[i];
            return (byte)(~sum+(byte)1);
        }

        private byte ASCIIcodeToByte(string data)
        {
            byte result = 0;
            int i, temp = 0;
            for(i = 0; i < data.Length; i++)
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

        public string byteToASCIIcode(byte data)
        {

            string result = "";
            char tmp=' ';

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
            for(int i=0;i<data.Length-1;i=i+2)
            {
                tmp += (char)ASCIIcodeToByte(data.Substring(i, 2));
            }
            return tmp;
        }
        private bool checkLRC(string frame)
        {
            //TODO  funkcja sprawdzajaca poprawnosc przeslania ramki
            if (frame==null || frame[0] != ':')
                return false;
            string srcForLRC = frame.Substring(1, frame.Length - 5);
            byte receivedLRC=ASCIIcodeToByte(frame.Substring(frame.Length-4,2));
            if(receivedLRC==generateLRC(srcForLRC))
                return true;
            else
                return false;
        }
        public string makeFrameToSend(byte adres, byte command, string args)
        {
            string frame = ":";
            frame+=byteToASCIIcode(adres)+byteToASCIIcode(command);
            for (int i = 0; i < args.Length; i++)
                frame += byteToASCIIcode((byte)args[i]);
            byte lrcSum = generateLRC(frame.Substring(1));
            frame += byteToASCIIcode(lrcSum);
            return frame;
        }
        public Action<string> FrameRecieved;
        public Action<string> TextRecieved;

    }
}
