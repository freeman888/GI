using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
                h.Add("IO.Input", new IO_Function_Input());
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

            public class IO_Function_Input : Function, IAsync
            {
                public IO_Function_Input()
                {
                    str_xcname = "title,text";
                    IInformation = "show a dialog to ask a text from user";
                }
                static Dictionary<int, Variable> rets = new Dictionary<int, Variable>();

                public object IReRun(Hashtable xc, int id)
                {
                    return rets[id];
                }
                
                class Flag
                {
                   public bool done = false;
                }
                public override object Run(Hashtable xc)
                {
                    Flag flag = new Flag();
                    var ex = new MyExceptions.AsyncException();
                    ex.reruner = this;
                    var task = Task.Run(() =>
                    {
                        while (!ex.breakdone) ;

                        MainWindow.MainApp.Dispatcher.Invoke(() =>
                        {
                            var window = new Window { Width = 300,Height = 200,MinHeight = 200,MaxHeight = 200,MaxWidth = 300,MinWidth = 300};
                            var grid = new Grid {};
                            var label = new Label { Content = xc.GetCSVariable<object>("title").ToString(), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(20), FontSize = 14 };

                            var textbox = new TextBox { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Center, Margin = new Thickness(10),Text = xc.GetCSVariable<object>("text").ToString() };
                            var button = new Button { HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Bottom,
                                Content = "OK",
                                Padding = new Thickness(3),
                                Margin = new Thickness(5),
                                FontSize = 14,
                            };
                            button.Click += (s, e) =>
                              {
                                  rets.Add(ex.id, new Variable(textbox.Text));
                                  flag.done = true;
                                  window.Close();
                              };
                            grid.Children.Add(label);
                            grid.Children.Add(textbox);
                            grid.Children.Add(button);
                            window.Closed += (s, e) =>
                              {
                                  flag.done = true;
                                  if (rets.ContainsKey(ex.id))
                                      return;
                                  rets.Add(ex.id, new Variable(""));
                              };
                            window.Content = grid;
                            window.Show();
                        });
                        while (!flag.done) ;
                    });
                    ex.task = task;
                    throw (ex);
                }
            }
        }

    }
}

