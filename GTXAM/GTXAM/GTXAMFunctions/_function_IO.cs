using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GI;
using static GI.Function;

namespace GTXAM.GTXAMFunctions
{
    public partial class GTXAMFunction
    {
        public class IO_Head:Head
        {
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
                }
                public override object Run(Hashtable xc)
                {
                    try
                    {
                        string text = ((Variable)xc["text"]).value.ToString();
                        ((App.MainApp.MainPage as Xamarin.Forms.NavigationPage).CurrentPage as ConsolePage).ConsoleWrite(text + Environment.NewLine);
                    }
                    catch
                    {
                        throw new Exception("控制台已被销毁");
                    }
                    return new Variable(this);
                }
            }
            public class IO_Function_Write : Function
            {
                public IO_Function_Write()
                {
                    str_xcname = "text";
                }
                public override object Run(Hashtable xc)
                {
                    try
                    {
                        var page = (ConsolePage)(App.MainApp.MainPage as Xamarin.Forms.NavigationPage).RootPage;
                        var text = xc.GetVariable<object>("text").ToString();
                        page.ConsoleWrite(text);
                    }
                    catch
                    {
                        throw new Exception("控制台已被销毁");
                    }
                    return new Variable(this);
                }
            }

            public class IO_Function_Tip : Function
            {
                public IO_Function_Tip()
                {
                    str_xcname = "tip";
                }
                public override object Run(Hashtable xc)
                {
                    string text = Variable.GetTrueVariable<object>(xc, "tip").ToString();
                    App.MainApp.MainPage.DisplayAlert("提示", xc.GetVariable<object>("tip").ToString(), "确定");

                    return new Variable(0);
                }
            }
        }
    }
}
