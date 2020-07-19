using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static GI.Lib;

namespace GTXAM
{
  
    partial class Lib
    {
        public class Page_Lib:ILib
        {

            public Page_Lib()
            {

                myThing.Add("Page", new Variable(new PageClassTemplate()));
                myThing.Add("PageGo", new Variable(new Page_Function_GotoPage()));
                myThing.Add("PageReturn", new Variable(new Page_Function_Return()));
                myThing.Add("PageLoad", new Variable(new Page_Function_Load()));
            }


            public class PageClassTemplate : GClassTemplate
            {
                public PageClassTemplate() : base("page", "Page")
                {
                    Istr_xcname = "title";
                    csctor = (xc) =>
                    {
                        string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                        GasControl.Page.Page gasPage = new GasControl.Page.Page(title);
                        gasPage.BackgroundColor = Xamarin.Forms.Color.White;
                        return gasPage;
                    };
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
                    GasControl.Page.Page page = xc.GetCSVariableFromSpeType<GasControl.Page.Page>("page", "page");
                    System.Diagnostics.Debug.WriteLine(page.Title);

                    Task.Run(() =>
                    {
                        Device.BeginInvokeOnMainThread(async () =>
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
                    Page p = consolePage.Navigation.PopAsync().Result;
                    return new Variable(p);
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
                    GasControl.Page.Page page = xc.GetCSVariableFromSpeType<GasControl.Page.Page>("page", "page");
                    if ((App.MainApp.MainPage as NavigationPage).CurrentPage.GetType() != typeof(ConsolePage))
                    {
                        throw new Exceptions.RunException(Exceptions.EXID.逻辑错误, "请勿多次调用本方法");
                    }

                    Task.Run(() =>
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {

                            App.MainApp.MainPage = new NavigationPage(page);
                        });
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
