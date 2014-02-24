using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace IwSK_RS232.PlainCommunication
{
    class Parser
    {
        public List<char> buffer = new List<char>();
        private ConcurrentQueue<string> cmds = new ConcurrentQueue<string>();
        private object locker = new object();

        public void Append(char c)
        {
            lock (locker)
            {
                buffer.Add(c);
                if (EndOfFileFound() && CommandRecognized != null)
                    CommandRecognized();
            }
        }

        public void Append(char[] c)
        {
            lock (locker)
            {
                buffer.AddRange(c);
                if (EndOfFileFound() && CommandRecognized != null)
                    CommandRecognized();
            }
        }

        public void Append(string s)
        {
            lock (locker)
            {
                Append(s.ToCharArray());
            }
        }
        /// <summary>
        /// Scans through bytes collection and searches for end-of-frame.
        /// TODO: make this independant of one end frame (should support /r, /n and /r/n)
        /// </summary>
        private bool EndOfFileFound()
        {
            bool ret = false;
            int end;
            int beg = end = 0;

            lock (locker)
            {    
                for (int i = 0; i < buffer.Count; i++)
                {
                    if (buffer[i] == '\r' && i != buffer.Count - 1 && i != 0 && buffer[i + 1] == '\n')
                    {
                        end = i + 1;
                        cmds.Enqueue(new string(buffer.GetRange(beg, end - beg + 1).ToArray()));
                        beg = end + 1;
                        ret = true;
                    }
                }
                buffer.Clear();
            }
            return ret;
        }

        public bool HasNextCommand()
        {
            return !cmds.IsEmpty;
        }

        public bool GetNextCommand(out string msg)
        {
            return cmds.TryDequeue(out msg);
        }

        public Action CommandRecognized;
    }
}
