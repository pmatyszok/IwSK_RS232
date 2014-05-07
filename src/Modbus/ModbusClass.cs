using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
namespace IwSK_RS232.Modbus
{
    
    class ModbusClass
    {
        private string frameToSend;
        private ConcurrentQueue<string> receivedFrames = new ConcurrentQueue<string>();
        private bool isMaster;
        public void addFrame(string frame)
        {
            receivedFrames.Enqueue(frame);
            
        }
        public void setMaster()
        {
            isMaster = true;
        }
        public void setSlave()
        {
            isMaster = false; 
        }

 

    }
}
