using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using GI;
using static GI.Function;

namespace GTWPF
{
    partial class GTWPFFunction
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
                h.Add("Page.AddTool", new Page_Function_AddTool());
            }
            public class Page_Function_Creat : Function
            {
                public Page_Function_Creat()
                {
                    IInformation = "Creat a new page with title and return";
                    str_xcname = "title";
                }
                public override object Run(Hashtable xc)
                {
                    string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                    GasControl.Page.GasPage gasPage = new GasControl.Page.GasPage(title);
                    gasPage.Background = Brushes.White;
                    return new Variable(gasPage);
                }
            }


            public class Page_Function_SetContent : Function
            {
                public Page_Function_SetContent()
                {
                    IInformation = "set the control as the content of the page";
                    str_xcname = "page,control";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.Page.GasPage gasPage = Variable.GetTrueVariable<GasControl.Page.GasPage>(xc, "page");
                    UIElement control = Variable.GetTrueVariable<UIElement>(xc, "control");
                    gasPage.SetContent(control);
                    return new Variable(0);
                }
            }

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
                    if (mainWindow. Pages.Count == 0)
                    {
                        throw new Exception("请先通过  Page.LoadApp(page)   方法确定主页面，然后再使用本方法");
                    }
                    lock (mainWindow)
                    {
                        GasControl.Page.GasPage page = Variable.GetTrueVariable<GasControl.Page.GasPage>(xc, "page");
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
                    if(mainWindow.Pages.Count >1)
                    {
                        throw new Exception("请勿多次调用本方法");
                    }
                    GasControl.Page.GasPage page = Variable.GetTrueVariable<GasControl.Page.GasPage>(xc, "page");
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
            
            public class Page_Function_SetTitle : Function
            {
                public Page_Function_SetTitle()
                {
                    IInformation = "set the title of the page";
                    str_xcname = "page,title";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.Page.GasPage page = Variable.GetTrueVariable<GasControl.Page.GasPage>(xc, "page");
                    string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                    if(MainWindow.MainApp.PageBase.Children.Contains(page))
                    {
                        MainWindow.MainApp.GasTitle.Content = title;
                    }
                    page.title = title;
                    return new Variable(0);
                }
            }

            public class Page_Function_AddTool:Function
            {
                public Page_Function_AddTool()
                {
                    str_xcname = "page,text,clickevent";
                    IInformation = "Add a toolitem to page";
                }

                public override object Run(Hashtable xc)
                {
                    var page = xc.GetCSVariable<GasControl.Page.GasPage>("page");
                    var text = xc.GetCSVariable<object>("text").ToString();
                    var click = xc.GetCSVariable<object>("clickevent");
                    page.AddTool(text, click);
                    return new Variable(0);
                }
            }
            
        }
    }
}
