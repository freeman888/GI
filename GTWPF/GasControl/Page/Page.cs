using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GI;
using static GI.Function;

namespace GTWPF.GasControl.Page
{


    /// <summary>
    /// Gasoline页面
    /// </summary>
    public class GasPage : Grid, IFunction, IOBJ
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
                {"AddTool",new Variable(new MFunction(addtool,this)) }
            };
        }

        internal StackPanel sp_tools = new StackPanel
        {
            HorizontalAlignment = HorizontalAlignment.Right,
            Margin = new Thickness(10),
        };
        internal bool hastool = false;

        internal void AddTool(string text, object click_event)
        {
            //hastool = true;
            //var grid = new Grid
            //{
            //    Children =
            //    {
            //        new Label
            //        {
            //            Content = text,
            //            FontSize = 16
            //        }
            //    },
            //    Background = Brushes.White
            //};
            //grid.MouseDown += async (s, e) =>
            // {
            //     if (click_event != null)
            //     {
            //         if (click_event is IFunction)
            //         {
            //             IFunction function = click_event as IFunction;
            //             Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
            //             string[] sss = function.Istr_xcname.Split(',');
            //             if (sss.Length == 2)
            //             {
            //                 hashtable.Add(sss[0], new Variable(this));
            //                 hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
            //                 await Function.AsyncFuncStarter(function, hashtable);
            //             }
            //         }
            //         else
            //         {
            //             IFunction function = Variable.GetTrueVariable<IFunction>(Gasoline.sarray_Sys_Variables, click_event.ToString());
            //             Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
            //             string[] sss = function.Istr_xcname.Split(',');
            //             if (sss.Length == 2)
            //             {
            //                 hashtable.Add(sss[0], new Variable(this));
            //                 hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
            //                 await Function.AsyncFuncStarter(function, hashtable);
            //             }
            //         }
            //     };
            // };
            //grid.MouseEnter += (s, e) =>
            //{
            //    grid.Background = new BrushConverter().ConvertFromString("#50000000") as Brush;
            //};
            //grid.MouseLeave += (s, e) =>
            //{
            //    grid.Background = Brushes.White;
            //};
            //sp_tools.Children.Add(grid);
        }
        public string title;
        public void SetContent(UIElement control)
        {
            Children.Clear();
            Children.Add(control);
        }

        #region
        public bool Iisasync { get { return false; } set { } }

        public Task<object> IAsyncRun(Hashtable xc)
        {
            throw new Exception();
        }
        public string IInformation { get => "to be added"; set => throw new NotImplementedException(); }
        string IFunction.Istr_xcname
        {
            get { return "params"; }
            set { }
        }
        bool IFunction.Iisreffunction
        {
            get { return false; }
            set { }
        }

        public string poslib { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        object IFunction.IRun(Hashtable xc)
        {

            var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");
            switch (arrayList.Count)
            {
                case 1:
                    {
                        return new Variable((Children[0] as Control.IGetter).IFindID((arrayList[0] as Variable).value.ToString()));
                    }
                case 0:
                    {
                        return new Variable(new Function.DFunction
                        {
                            str_xcname = "con",
                            dRun = (dxc) =>
                            {
                                SetContent(Variable.GetTrueVariable<UIElement>(dxc, "con"));
                                return new Variable(0);
                            }
                        });
                    }
            }
            return new Variable(0);
        }
        #endregion
        #region 实现Itype
        const string type = "page";
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
            GType.Sign("page");
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
        IFunction setcontent = new Page_Function_SetContent();
        public class Page_Function_SetContent : Function
        {
            public Page_Function_SetContent()
            {
                IInformation = "set the control as the content of the page";
                str_xcname = "control";
            }
            public override object Run(Hashtable xc)
            {
                var page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("this", "page");
                UIElement control = Variable.GetTrueVariable<UIElement>(xc, "control");
                page.SetContent(control);
                return new Variable(0);
            }
        }
        IFunction settitle = new Page_Function_SetTitle();
        public class Page_Function_SetTitle : Function
        {
            public Page_Function_SetTitle()
            {
                IInformation = "set the title of the page";
                str_xcname = "title";
            }
            public override object Run(Hashtable xc)
            {
                var page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("this", "page");
                string title = Variable.GetTrueVariable<object>(xc, "title").ToString();
                if (MainWindow.MainApp.PageBase.Children.Contains(page))
                {
                    MainWindow.MainApp.GasTitle.Content = title;
                }
                page.title = title;
                return new Variable(0);
            }
        }
        IFunction addtool = new Page_Function_AddTool();
        public class Page_Function_AddTool : Function
        {
            public Page_Function_AddTool()
            {
                str_xcname = "text,clickevent";
                IInformation = "Add a toolitem to page";
            }

            public override object Run(Hashtable xc)
            {
                var page = xc.GetCSVariableFromSpeType<GasControl.Page.GasPage>("this","page");
                var text = xc.GetCSVariable<object>("text").ToString();
                var click = xc.GetCSVariable<object>("clickevent");
                page.AddTool(text, click);
                return new Variable(0);
            }
        }
    }
}
