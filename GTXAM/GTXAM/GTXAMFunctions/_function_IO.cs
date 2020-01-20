using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GI;
using Xamarin.Forms;
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
                h.Add("IO.Input", new IO_Function_Input());
            }

            public class IO_Function_Input:AFunction
            {
                public IO_Function_Input()
                {
                    IInformation += @"params:
1 title
2 title tips
return:
when tap 'ok' return what was inputed
when tap 'cancel' or close the inputwindow , return a empty string";
                    Istr_xcname = "params";
                }
                public async override Task<object> Run(Hashtable xc)
                {
                    var list = xc.GetCSVariable<Glist>("params");
                    Variable ret;
                    if (list.Count == 0)
                        ret = new Variable(await App.MainApp.MainPage.DisplayPromptAsync("Input", ""));
                    else if (list.Count == 1)
                        ret = new Variable(await App.MainApp.MainPage.DisplayPromptAsync(list[0].value.IGetCSValue().ToString(), ""));
                    else if (list.Count == 2)
                        ret = new Variable(await App.MainApp.MainPage.DisplayPromptAsync(list[0].value.IGetCSValue().ToString(), list[1].value.IGetCSValue().ToString()));
                    else throw new Exceptions.RunException(Exceptions.EXID.参数错误);
                    return ret;
                }
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
                        throw new Exceptions.RunException(Exceptions.EXID.逻辑错误,"控制台已被销毁");
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
                        throw new Exceptions.RunException(Exceptions.EXID.逻辑错误, "控制台已被销毁");
                    }
                    return new Variable(this);
                }
            }

            public class IO_Function_Tip : AFunction
            {
                public IO_Function_Tip()
                {
                    Istr_xcname = "tip";
                }
                public async override Task<object> Run(Hashtable xc)
                {
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        string text = Variable.GetTrueVariable<object>(xc, "tip").ToString();
                        await App.MainApp.MainPage.DisplayAlert("提示", xc.GetVariable<object>("tip").ToString(), "确定");

                    });
                    return new Variable(0);
                }
            }
        }
    }
}
