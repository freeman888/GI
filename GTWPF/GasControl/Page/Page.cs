using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GI;

namespace GTWPF.GasControl.Page
{


    /// <summary>
    /// Gasoline页面
    /// </summary>
    public class GasPage : Grid,IFunction
    {
       

        public GasPage(string title)
        {
            this.title = title;
            Background = Brushes.White;
            Children.Add(new GasControl.Control.Tip() { Text = "Welcome to use Gasoline.Page", VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });
        }

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
            grid.MouseDown +=async (s, e) =>
            {
                if (click_event != null)
                {
                    if (click_event is IFunction)
                    {
                        IFunction function = click_event as IFunction;
                        Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                        string[] sss = function.Istr_xcname.Split(',');
                        if (sss.Length == 2)
                        {
                            hashtable.Add(sss[0], new Variable(this));
                            hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
                            await Function.AsyncFuncStarter(function, hashtable);
                        }
                    }
                    else
                    {
                        IFunction function = Variable.GetTrueVariable<IFunction>(Gasoline.sarray_Sys_Variables, click_event.ToString());
                        Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                        string[] sss = function.Istr_xcname.Split(',');
                        if (sss.Length == 2)
                        {
                            hashtable.Add(sss[0], new Variable(this));
                            hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
                            await Function.AsyncFuncStarter(function, hashtable);
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
        object IFunction.IRun(Hashtable xc)
        {

            var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");
            switch (arrayList.Count)
            {
                case 1:
                    {
                        return new Variable ((Children[0] as Control.IGetter).IFindID((arrayList[0] as Variable).value.ToString()));
                    }
                case 0:
                    {
                        return new Variable(new Function.DFunction {
                            str_xcname = "con",
                            dRun = (dxc)=>
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
        const string type = "page,function";
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

    }
}
