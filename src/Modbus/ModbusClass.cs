using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
namespace IwSK_RS232.Modbus
{
    
    class ModbusClass
    {
        private byte stationAddress;
        private string frameToSend;
        private ConcurrentQueue<string> receivedFrames = new ConcurrentQueue<string>();
        private bool isMaster;
        public void addFrame(string frame)
        {
            receivedFrames.Enqueue(frame);
            isMaster = true;
            byte lrc=generateLRC(frame.Substring(1,frame.Length-5));
            lrc=lrc;
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

        private byte stringToByte(string data)
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

        private string byteToString(byte data)
        {
            string result = " ";
            char tmp;
            int temp = data & 0x0F;
            if (temp >= 10 && temp <= 15)
            {
                tmp = Convert.ToChar(temp + 55);
            }
            if (temp >= 0 && temp <= 9)
            {
                tmp = Convert.ToChar(temp + 48);
            }


            temp = data & 0xF0;
            temp = temp >> 4;
            if (temp >= 10 && temp <= 15)
            {
                tmp = Convert.ToChar(temp + 55);
            }
            if (temp >= 0 && temp <= 9)
            {
                tmp = Convert.ToChar(temp + 48);
            }

            return result;
        }

 

    }
}
