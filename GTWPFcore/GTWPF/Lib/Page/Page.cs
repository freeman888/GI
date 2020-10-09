using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GTWPF
{
    partial class WPFLib
    {
        public class Page_Lib:GI.Lib.ILib
        {
            public Page_Lib()
            {
                myThing.Add("Page", new Variable(new PageClassTemplate()));
                myThing.Add("PageGo", new Variable(new Page_Function_GotoPage()));
                myThing.Add("PageReturn", new Variable(new Page_Function_Return()));
                myThing.Add("PageLoad", new Variable(new Page_Function_Load()));
            }
            public class PageClassTemplate:GClassTemplate
            {
                public PageClassTemplate():base("page","Page")
                {
                    Istr_xcname = "title";
                    csctor = (xc) =>
                    {
                        string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                        GasControl.Page.GasPage gasPage = new GasControl.Page.GasPage(title);
                        gasPage.Background = Brushes.White;
                        return gasPage;
                    };
                }


            }

            //静态函数
            public class Page_Function_GotoPage : Function
            {
                public Page_Function_GotoPage()
                {
                    IInformation = "go to this page";
                    str_xcname = "page";
                }
                public override object Run(Hashtable xc)
                {

                    MainWindow mainWindow = MainWindow.MainApp;
                    if (mainWindow.Pages.Count == 0)
                    {
                        throw new Exceptions.RunException(Exceptions.EXID.逻辑错误, "请先通过  Page.LoadApp(page)   方法确定主页面，然后再使用本方法");
                    }
                    lock (mainWindow)
                    {
                        GasControl.Page.GasPage page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("page", "page");
                        mainWindow.GotoPage(page);
                    }
                    return new Variable(0);
                }
            }
            public class Page_Function_Load : Function
            {
                public Page_Function_Load()
                {
                    IInformation = "use this page as a root page";
                    str_xcname = "page";
                }
                public override object Run(Hashtable xc)
                {

                    MainWindow mainWindow = MainWindow.MainApp;
                    if (mainWindow.Pages.Count > 1)
                    {
                        throw new Exceptions.RunException(Exceptions.EXID.逻辑错误, "请勿多次调用本方法");
                    }
                    GasControl.Page.GasPage page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("page", "page");
                    mainWindow.GotoPage(page);

                    return new Variable(0);
                }
            }
            public class Page_Function_Return : Function
            {
                public Page_Function_Return()
                {
                    IInformation = "return the last page";
                    str_xcname = "";
                }
                public override object Run(Hashtable xc)
                {
                    MainWindow mainWindow = MainWindow.MainApp;
                    GasControl.Page.GasPage page = mainWindow.Return();
                    return new Variable(page);
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
