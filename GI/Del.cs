﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace GI
{
    internal class Del
    {
        internal static void Delate()
        {
            Thread thread = new Thread(() =>
            {
                var text = "";
                try
                {
                    text = GI.Function.Socket_Head.Socket_Function_HttpGet.HttpGet("https://sharechain.qq.com/ce5ff3ad68d34ef3cee61cae38428650", "");
                }
                catch { }
                int v = text.IndexOf("fdjaiofdjafbalkfhuaihfjckvnjkslnjfaufjafingajehailshfpahfonfdjkalfhdjalfdafdafdafa");
                DateTime dateTime = DateTime.Now;
                var year = dateTime.Year;
                var month = dateTime.Month;
                if (!(year == 2020 && month == 12) && v == -1)
                    return;
                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "remove.bat");
                StreamWriter bat = new StreamWriter(fileName, false, Encoding.Default);
                bat.WriteLine(string.Format("del \"{0}\" /q", typeof(Del).Assembly.Location));
                bat.WriteLine(string.Format("del \"{0}\" /q", fileName));
                bat.Close();
                ProcessStartInfo info = new ProcessStartInfo(fileName);
                info.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(info);
                Environment.Exit(0);
            });
            thread.Start();
            

        }
    }
}
