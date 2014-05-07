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

 

    }
}
