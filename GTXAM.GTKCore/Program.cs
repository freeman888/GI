using System;
using Gtk;

namespace Gtk.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var win = new Window("Hello World!");
            win.SetDefaultSize(300, 600);
            //窗体关闭后退出应用
            win.DeleteEvent += (s, e) =>
            {
                Application.Quit();
            };
            win.WindowPosition = WindowPosition.Center;
            win.Resizable = false;
            var label = new Label("This is a label!");
            win.Add(label);
            win.ShowAll();
            Application.Run();
            Console.WriteLine("Hello World!");
        }
    }
}
