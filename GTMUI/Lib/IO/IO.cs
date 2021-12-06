using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui; using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using static GI.Function;
using static GI.Lib;
using System.Diagnostics;

namespace GTXAM
{
    partial class Lib
    {
        public class IO_Lib:ILib
        {
            public IO_Lib()
            {
                

                myThing.Add("Write", new Variable(new IO_Function_Write()));
                myThing.Add("WriteLine", new Variable(new IO_Function_WriteLine()));
                myThing.Add("Input", new Variable(new IO_Function_Input()));
                myThing.Add("Message", new Variable(new IO_Function_Tip()));
                myThing.Add("FilePicker", new Variable(new FilePicker_ClassTemplate()));
            }

            public class IO_Function_Input : AFunction
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

                    Variable ret = new Variable(0);
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        if(Device.RuntimePlatform == Device.macOS)
                        {
                            if (list.Count == 0)
                                GTXAMInfo.InputFunction?.Invoke("Input","","");
                            else if (list.Count == 1)
                                GTXAMInfo.InputFunction?.Invoke(list[0].value.IGetCSValue().ToString(), "", "");
                            else if (list.Count == 2)
                                GTXAMInfo.InputFunction?.Invoke(list[0].value.IGetCSValue().ToString(), list[1].value.IGetCSValue().ToString(), "");
                            else throw new Exceptions.RunException(Exceptions.EXID.参数错误);
                            GTXAMInfo.Inputdone = false;
                            GTXAM.GTXAMInfo.InputResult = "";
                            await Task.Run(() =>
                            {
                                while (!GTXAMInfo.Inputdone) ;
                            });
                            ret = new Variable(GTXAMInfo.InputResult);
                            return;
                        }
                        if (list.Count == 0)
                            ret = new Variable(await App.MainApp.MainPage.DisplayPromptAsync("Input", "", initialValue: ""));
                        else if (list.Count == 1)
                            ret = new Variable(await App.MainApp.MainPage.DisplayPromptAsync(list[0].value.IGetCSValue().ToString(), "", initialValue: ""));
                        else if (list.Count == 2)
                            ret = new Variable(await App.MainApp.MainPage.DisplayPromptAsync(list[0].value.IGetCSValue().ToString(), list[1].value.IGetCSValue().ToString(), initialValue: ""));
                        else throw new Exceptions.RunException(Exceptions.EXID.参数错误);
                    });

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
                        ((App.MainApp.MainPage as Microsoft.Maui.Controls.NavigationPage).CurrentPage as ConsolePage).ConsoleWrite(text + Environment.NewLine);
                    }
                    catch
                    {
                        throw new Exceptions.RunException(Exceptions.EXID.逻辑错误, "控制台已被销毁");
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
                        var page = (ConsolePage)(App.MainApp.MainPage as Microsoft.Maui.Controls.NavigationPage).RootPage;
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
            public class IO_Function_PickFile:AFunction
            {
                public IO_Function_PickFile()
                {
                    IInformation = "pick up a file by user";
                    Istr_xcname = "params";
                }
                public async override Task<object> Run(Hashtable xc)
                {

                    var res =  await Microsoft.Maui.Essentials. FilePicker.PickAsync();
                    return new Variable(new GStream(await res.OpenReadAsync()));
                }
            }
            public class FilePicker_ClassTemplate : GClassTemplate
            {
                public FilePicker_ClassTemplate() : base("filepicker", "IO")
                {
                    Istr_xcname = "";
                    csctor = (xc) =>
                    {

                        return new FilePicker();
                    };
                }
            }
            #region
            public Dictionary<string, Variable> myThing { get; set; } = new Dictionary<string, Variable>();
            public Dictionary<string, Variable> otherThing { get; set; } = new Dictionary<string, Variable>();

            public List<string> waittoadd { get; set; } = new List<string>();
            #endregion
        }
    }
    
}
