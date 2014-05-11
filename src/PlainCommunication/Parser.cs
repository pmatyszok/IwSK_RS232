using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace IwSK_RS232.PlainCommunication
{
    internal class Parser
    {
        private readonly ConcurrentQueue<string> _cmds = new ConcurrentQueue<string>();
        private readonly int _length;
        private readonly string _lineEnd;
        private readonly object _locker = new object();
        public Action CommandRecognized;
        public List<char> Buffer = new List<char>();

        public Parser(string lineEnd)
        {
            this._lineEnd = lineEnd;
            _length = lineEnd.Length;
        }

        public void Append(char c)
        {
            lock (_locker)
            {
                Buffer.Add(c);
                if (EndOfFileFound() && CommandRecognized != null)
                    CommandRecognized();
            }
        }

        public void Append(char[] c)
        {
            lock (_locker)
            {
                Buffer.AddRange(c);
                if (EndOfFileFound() && CommandRecognized != null)
                    CommandRecognized();
            }
        }

        public void Append(string s)
        {
            lock (_locker)
            {
                Append(s.ToCharArray());
            }
        }

        /// <summary>
        ///     Scans through bytes collection and searches for end-of-frame.
        ///     TODO: make this independant of one end frame (should support /r, /n and /r/n)
        /// </summary>
        private bool EndOfFileFound()
        {
            bool ret = false;
            int end;
            int beg = end = 0;

            lock (_locker)
            {
                for (int i = 0; i < Buffer.Count; i++)
                {
                    if (_length == 2 && Buffer[i] == _lineEnd[0] && i != Buffer.Count - 1 && i != 0 &&
                        Buffer[i + 1] == _lineEnd[1])
                    {
                        end = i + 1;
                        _cmds.Enqueue(new string(Buffer.GetRange(beg, end - beg + 1).ToArray()));
                        beg = end + 1;
                        ret = true;
                    }
                    else if (_length == 1 && Buffer[i] == _lineEnd[0])
                    {
                        end = i;
                        _cmds.Enqueue(new string(Buffer.GetRange(beg, end - beg).ToArray()));
                        beg = end;
                        ret = true;
                    }
                }
                Buffer.Clear();
            }
            return ret;
        }

        public bool HasNextCommand()
        {
            return !_cmds.IsEmpty;
        }

        public bool GetNextCommand(out string msg)
        {
            return _cmds.TryDequeue(out msg);
        }
    }
}