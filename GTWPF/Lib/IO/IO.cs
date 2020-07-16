using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static GI.Function;

namespace GTWPF
{
    partial class  WPFLib
    {
        public class IO_Lib : GI.Lib.ILib
        {

            public IO_Lib()
            {
                myThing.Add("Write", new Variable(new IO_Function_Write()));
                myThing.Add("WriteLine", new Variable(new IO_Function_WriteLine()));
                myThing.Add("Input", new Variable(new IO_Function_Input()));
                myThing.Add("Message", new Variable(new IO_Function_Tip()));
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
                    object done = false;
                    try
                    {
                        await MainWindow.MainApp.Dispatcher.InvokeAsync(async () =>
                        {
                            var input = new GwpfLib.IO.Input();
                            if (list.Count == 0)
                                ret = new Variable(await input.GetInput());
                            else if (list.Count == 1)
                                ret = new Variable(await input.GetInput(list[0].value.IGetCSValue().ToString(), ""));
                            else if (list.Count == 2)
                                ret = new Variable(await input.GetInput(list[0].value.IGetCSValue().ToString(), list[1].value.IGetCSValue().ToString()));
                            else throw new Exceptions.RunException(Exceptions.EXID.参数错误);
                            done = true;
                        });
                        await Task.Run(() =>
                        {
                            while (!Convert.ToBoolean(done)) ;
                        });
                    }
                    catch
                    {
                        throw new Exceptions.RunException(Exceptions.EXID.未知);
                    }
                    return ret;
                }
            }
            public class IO_Function_Tip : AFunction
            {
                public IO_Function_Tip()
                {
                    Istr_xcname = "tip";
                    IInformation = "[tip]:the text to be tipped to the user.\nusing this methord to tip user.";

                }
                public async override Task<object> Run(Hashtable xc)
                {
                    string text = Variable.GetTrueVariable<object>(xc, "tip").ToString();
                    await Task.Run(() =>
                    {
                        MessageBox.Show(text);
                    });
                    return new Variable(0);
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
