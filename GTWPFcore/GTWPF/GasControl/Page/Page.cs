using GI;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using static GI.Function;

namespace GTWPF.GasControl.Page
{


    /// <summary>
    /// Gasoline页面
    /// </summary>
    public class GasPage : Grid, IOBJ
    {


        public GasPage(string title)
        {
            this.title = title;
            Background = Brushes.White;
            //Children.Add(new GasControl.Control.Tip() { Text = "Welcome to use Gasoline.Page", VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });
            members = new Dictionary<string, Variable>
            {
                {"SetContent",new Variable(new MFunction(setcontent,this)) },
                {"SetTitle",new Variable(new MFunction(settitle,this)) },
                {"AddTool",new Variable(new MFunction(addtool,this)) },
                {"LoadFromXml",new Variable(new MFunction(loadfromxml,this)) },
                {"GetControlByName",new Variable(new MFunction(getcontrolbyname,this)) }
            };
        }
        internal Dictionary<string, IOBJ> controls = new Dictionary<string, IOBJ>();

        internal StackPanel sp_tools = new StackPanel
        {
            HorizontalAlignment = HorizontalAlignment.Right,
            Margin = new Thickness(10),
        };
        internal bool hastool = false;

        internal void AddTool(string text, object click_event)
        {
            hastool = true;
            var grid = new Grid
            {
                Children =
                {
                    new Label
                    {
                        Content = text,
                        FontSize = 16
                    }
                },
                Background = Brushes.White
            };
            grid.MouseDown += async (s, e) =>
             {
                 if (click_event != null)
                 {
                     if (click_event is IFunction)
                     {
                         IFunction function = click_event as IFunction;
                         string[] sss = function.Istr_xcname.Split(',');
                         if (sss.Length == 2)
                         {
                             await Function.NewAsyncFuncStarter(function, new Variable(this), new Variable(e));
                         }
                     }
                     else
                     {
                         IFunction function = Variable.GetTrueVariable<IFunction>(Gasoline.sarray_Sys_Variables, click_event.ToString());
                         string[] sss = function.Istr_xcname.Split(',');
                         if (sss.Length == 2)
                         {
                             await Function.NewAsyncFuncStarter(function, new Variable(this), new Variable(e));
                         }
                     }
                 };
             };
            grid.MouseEnter += (s, e) =>
            {
                grid.Background = new BrushConverter().ConvertFromString("#50000000") as Brush;
            };
            grid.MouseLeave += (s, e) =>
            {
                grid.Background = Brushes.White;
            };
            sp_tools.Children.Add(grid);
        }
        public string title;
        public void SetContent(UIElement control)
        {
            Children.Clear();
            Children.Add(control);
        }

        #region 实现Itype
        const string type = "Page";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }

        public object IGetCSValue()
        {
            return this;
        }
        static GasPage()
        {
            GType.Sign("Page");
        }
        #endregion
        #region
        Dictionary<string, Variable> members = new Dictionary<string, Variable>();
        public Variable IGetMember(string name)
        {
            if (members.ContainsKey(name))
                return members[name];
            else return null;
        }

        public IOBJ IGetParent()
        {
            return null;
        }

        #endregion


        //member function
        static IFunction setcontent = new Page_Function_SetContent();
        public class Page_Function_SetContent : Function
        {
            public Page_Function_SetContent()
            {
                IInformation = "set the control as the content of the page";
                str_xcname = "control";
            }
            public override object Run(Hashtable xc)
            {
                var page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("this", "Page");
                UIElement control = xc.GetCSVariableFromSpeType<UIElement>("control", "Control");
                page.SetContent(control);
                return new Variable(0);
            }
        }
        static IFunction settitle = new Page_Function_SetTitle();
        public class Page_Function_SetTitle : Function
        {
            public Page_Function_SetTitle()
            {
                IInformation = "set the title of the page";
                str_xcname = "title";
            }
            public override object Run(Hashtable xc)
            {
                var page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("this", "Page");
                string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                if (MainWindow.MainApp.PageBase.Children.Contains(page))
                {
                    MainWindow.MainApp.GasTitle.Content = title;
                }
                page.title = title;
                return new Variable(0);
            }
        }
        static IFunction addtool = new Page_Function_AddTool();
        public class Page_Function_AddTool : Function
        {
            public Page_Function_AddTool()
            {
                str_xcname = "text,clickevent";
                IInformation = "Add a toolitem to page";
            }

            public override object Run(Hashtable xc)
            {
                var page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("this", "Page");
                var text = xc.GetCSVariable<object>("text").ToString();
                var click = xc.GetCSVariable<object>("clickevent");
                page.AddTool(text, click);
                return new Variable(0);
            }
        }

        static IFunction loadfromxml = new Page_LoadFromXml();
        public class Page_LoadFromXml : Function
        {
            public Page_LoadFromXml()
            {
                str_xcname = "xmlstream";
                IInformation = "Load a page from xml file";
            }

            public override object Run(Hashtable xc)
            {
                var page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("this", "Page");
                var stream = xc.GetCSVariableFromSpeType<System.IO.Stream>("xmlstream", "Stream");
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(stream);

                XmlElement xmlElement = xmlDocument.DocumentElement;
                //Title属性
                try
                {
                    var title = xmlElement.GetAttribute("Title");
                    if (MainWindow.MainApp.PageBase.Children.Contains(page))
                    {
                        MainWindow.MainApp.GasTitle.Content = title;
                    }
                    page.title = title;
                }
                catch { }
                //加载页面内容
                XmlElement xe_content = xmlElement.FirstChild as XmlElement;
                var content = GTWPF.Control.GetControlFromXmlElement(page, xe_content);

                page.SetContent(content.IGetCSValue() as UIElement);

                return new Variable(0);
            }
        }

        static IFunction getcontrolbyname = new Page_GetControlByName();
        public class Page_GetControlByName : Function
        {
            public Page_GetControlByName()
            {
                str_xcname = "name";
                IInformation = "get control by name from page";
            }

            public override object Run(Hashtable xc)
            {
                return new Variable(xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("this", "Page").controls[xc.GetCSVariable<object>("name").ToString()]);
            }
        }
    }
}
