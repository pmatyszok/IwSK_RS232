using System;
using System.Windows.Forms;

namespace IwSK_RS232.Tools
{
    static class Log
    {
        public static RichTextBox Console { get; set; }

        public static void Append(string data)
        {
            Console.Invoke((MethodInvoker)delegate
            {
                Console.AppendText(DateTime.Now + " " + data + Environment.NewLine);
                Console.ScrollToCaret();
            });
        }
    }
}
