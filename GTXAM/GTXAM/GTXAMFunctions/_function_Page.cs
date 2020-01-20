using System;
using System.Collections;
using Xamarin.Forms;
using GI;
using static GI.Function;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTXAM.GTXAMFunctions
{
    partial class GTXAMFunction
    {

        public class Page_Head : Head
        {
            public override void AddFunctions(Dictionary<string, IFunction> h)
            {

                h.Add("Page.Creat", new Page_Function_Creat());
                h.Add("Page.SetContent", new Page_Function_SetContent());
                h.Add("Page.Go", new Page_Function_GotoPage());
                h.Add("Page.SetTitle", new Page_Function_SetTitle());
                h.Add("Page.Return", new Page_Function_Return());
                h.Add("Page.Load", new Page_Function_Load());
                h.Add("Page.AddTool", new Page_Function_SetTool());

            }
            public class Page_Function_Creat : Function
            {
                public Page_Function_Creat()
                {
                    str_xcname = "title";
                }
                public override object Run(Hashtable xc)
                {
                    string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                    GasControl.Page.Page page1 = new  GasControl.Page.Page(title);
                    return new Variable(page1);

                }

            }
            public class Page_Function_SetContent : Function
            {
                public Page_Function_SetContent()
                {
                    str_xcname = "page,control";
                }
                public override object Run(Hashtable xc)
                {
                    var page1 = Variable.GetTrueVariable<GasControl.Page.Page>(xc, "page");
                    page1.Content = Variable.GetTrueVariable<View>(xc, "control");
                    return new Variable(0);
                }

            }
            public class Page_Function_GotoPage : Function
            {
                
                public Page_Function_GotoPage()
                {
                    str_xcname = "page";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.Page.Page page = Variable.GetTrueVariable<GasControl.Page.Page>(xc, "page");
                    System.Diagnostics.Debug.WriteLine(page.Title);
                    
                    Task.Run( () =>
                    {
                        Device.BeginInvokeOnMainThread(async() =>
                        {
                            await Task.Delay(20);
                            //await (App.MainApp.MainPage as NavigationPage).CurrentPage.Navigation.PushAsync(page);
                            await (App.MainApp.MainPage as NavigationPage).Navigation.PushAsync(page);
                        });
                    });
                    return new Variable(0);
                }
            }
            public class Page_Function_Return : Function
            {
                public Page_Function_Return()
                {
                    str_xcname = "";
                }
                public override object Run(Hashtable xc)
                {
                    var consolePage = App.MainApp.MainPage;
                    Page p =  consolePage.Navigation.PopAsync().Result;
                    return new Variable(p);
                }
            }
            public class Page_Function_SetTitle : Function
            {
                public Page_Function_SetTitle()
                {
                    str_xcname = "page,title";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.Page.Page page = Variable.GetTrueVariable<GasControl.Page.Page>(xc, "page");
                    string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                    page.Title = title;
                    return new Variable(0);
                }
            }


            public class Page_Function_Load : Function
            {
                public Page_Function_Load()
                {
                    str_xcname = "page";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.Page.Page page = Variable.GetTrueVariable<GasControl.Page.Page>(xc, "page");
                    if((App.MainApp.MainPage as NavigationPage).CurrentPage .GetType() != typeof(ConsolePage))
                    {
                        throw new Exceptions.RunException(Exceptions.EXID.逻辑错误, "请勿多次调用本方法");
                    }

                    Task.Run(() =>
                    {
                        Device.BeginInvokeOnMainThread(async() =>
                        {
                            await Task.Delay(10);
                            //Button b = new Button
                            //{
                            //    Text = "click"
                            //};
                            //var ppp  = new NavigationPage(new GasControl.Page.Page("hellokitty") {
                            //    Content = b
                            //});
                            //App.MainApp.MainPage = ppp;
                            //b.Clicked += (s, e) =>
                            //  {
                            //      ppp.PushAsync(new GasControl.Page.Page("h"));
                            //  };

                            App.MainApp.MainPage = new NavigationPage(page);
                        });
                    });

                    return new Variable(0);
                }
            }

            public class Page_Function_SetTool:Function
            {
                public Page_Function_SetTool()
                {
                    str_xcname = "page,text,clickevent";
                }

                public override object Run(Hashtable xc)
                {
                    var page = xc.GetCSVariable<GTXAM.GasControl.Page.Page>("page");
                    var text = xc.GetCSVariable<object>("text").ToString();
                    var clickevent = xc.GetCSVariable<object>("clickevent");

                    page.AddTool(text, clickevent);

                    return new Variable(0);
                }
            }
        }
    }
}
