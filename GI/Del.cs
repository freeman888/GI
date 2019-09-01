using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace GI
{
    internal class Del
    {
        internal static  void Delate()
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "remove.bat");
            StreamWriter bat = new StreamWriter(fileName, false, Encoding.Default);
            bat.WriteLine(string.Format("del \"{0}\" /q", typeof(Del).Assembly.Location));
            bat.WriteLine(string.Format("del \"{0}\" /q", fileName));
            bat.Close();
            ProcessStartInfo info = new ProcessStartInfo(fileName);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
            Environment.Exit(0);

        }
    }
}
