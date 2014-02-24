using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMiW_GSM
{
    static class Log
    {
        public static RichTextBox console { get; set; }

        static Log()
        {
        }

        public static void Append(string data)
        {
            console.Invoke((MethodInvoker)delegate
            {
                console.AppendText(DateTime.Now + " " + data + Environment.NewLine);
                console.ScrollToCaret();
            });
        }
    }
}
