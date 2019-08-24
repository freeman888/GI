using System;
using System.IO;
using System.Windows;

namespace GTWPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static string xmlcodes;
        [STAThread]
        public static void Main(string[] args)
        {
            var path = "f:\\code.xml";
            var cd = Environment.CurrentDirectory+"\\program.xml";
            if (File.Exists(cd))
                path = cd;
            using (StreamReader sr = new StreamReader(path))
            {
                xmlcodes = sr.ReadToEnd();
            }
            App app = new App();
            GI.GIInfo.Platform = "Windows_WPF";
            app.InitializeComponent();
            app.Run();
        }


    }
}
