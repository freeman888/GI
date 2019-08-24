using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using static GI.Function;

namespace GTWPF
{
    partial class GTWPFFunction
    {

        public class IO_Head : Head
        {
            //注册
            public override void AddFunctions(Dictionary<string, IFunction> h)
            {
                h.Add("IO.Write", new IO_Function_Write());
                h.Add("IO.Tip", new IO_Function_Tip());
                h.Add("IO.WriteLine", new IO_Function_WriteLine());

            }
            public class IO_Function_WriteLine : Function
            {
                public IO_Function_WriteLine()
                {
                    str_xcname = "text";
                    IInformation = "[text]:the text to be written to the console page;\nusing this methord to write text to tip user,only write one line and will change line auto.";

                }
                public override object Run(Hashtable xc)
                {
                    string text = ((Variable)xc["text"]).value.ToString();
                    MainWindow page = MainWindow.MainApp;
                    page.Dispatcher.Invoke(() =>
                    {
                        page.Addtext(text + Environment.NewLine);
                    });
                    return new Variable(this);
                }
            }
            public class IO_Function_Write : Function
            {
                public IO_Function_Write()
                {
                    str_xcname = "text";
                    IInformation = "[text]:the text to be written to the console page;\nusing this methord to write text to tip user.";
                }
                public override object Run(Hashtable xc)
                {
                    string text = ((Variable)xc["text"]).value.ToString();
                    MainWindow page = MainWindow.MainApp;
                    page.Dispatcher.Invoke(() =>
                    {
                        page.Addtext(text);
                    });
                    return new Variable(this);
                }
            }

            public class IO_Function_Tip : Function
            {
                public IO_Function_Tip()
                {
                    str_xcname = "tip";
                    IInformation = "[tip]:the text to be tipped to the user.\nusing this methord to tip user.";

                }
                public override object Run(Hashtable xc)
                {
                    string text = Variable.GetTrueVariable<object>(xc, "tip").ToString();
                    Thread thread = new Thread(new ParameterizedThreadStart(Show));
                    thread.Start(text);
                    return new Variable(0);
                }

                public void Show(object a)
                {
                    MessageBox.Show(a.ToString());
                }
            }
        }

    }
}

