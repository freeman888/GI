using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Collections;
using GI;
using System.Threading.Tasks;

namespace GTWPF.GasControl.Control
{
    public class Switcher:StackPanel ,ISetter,IFunction,IGetter
    {
        private bool istoggled = false;
        
        public bool IsToggled
        {
            get
            {
                return istoggled;
            }
            set
            {
                istoggled = value;
                pic.Source = value ? on : off;
                label.Content = value ? "on" : "off";
            }
        }

        public string Istr_xcname { get => "params"; set => throw new Exception(); }
        public bool Iisreffunction { get => false; set => throw new Exception(); }
        public string IInformation { get => "to be added"; set => throw new Exception(); }

        static BitmapImage on = new BitmapImage(new Uri(@"pack://application:,,,/GasControl/Control/SwitcherRes/on.png")), off = new BitmapImage(new Uri(@"pack://application:,,,/GasControl/Control/SwitcherRes/off.png"));
        private Image pic = new Image() { Source = on, VerticalAlignment = System.Windows.VerticalAlignment.Center,HorizontalAlignment = System.Windows.HorizontalAlignment.Center,Margin = new System.Windows.Thickness(1)};
        Brush background = Brushes.Transparent;
        private Label label;
        public Switcher()
        {
            HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Height = 30;
            Orientation = Orientation.Horizontal;
            label = new Label() { VerticalAlignment = System.Windows.VerticalAlignment.Center,HorizontalAlignment = System.Windows.HorizontalAlignment.Center,Margin = new System.Windows.Thickness(1)};
            IsToggled = false;
            Children.Add(pic);
            Children.Add(label);

            MouseDown += async (s, e) =>
            {
                IsToggled = !IsToggled;

                if (function_Click == null)
                    return;
                var p = Parent;
                while (!(p is Page.GasPage))
                {
                    p = (p as FrameworkElement).Parent;
                }
                Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                string[] sss = function_Click.Istr_xcname.Split(',');
                if (sss.Length == 2)
                {
                    hashtable.Add(sss[0], new Variable(p));
                    hashtable.Add(sss[1], new Variable(e));
                    await Function.AsyncFuncStarter(function_Click, hashtable);
                }
            };

            MouseEnter += (s, e) =>
            {
                Background = new BrushConverter().ConvertFromString("#10000000")as Brush;
            };

            MouseLeave += (s, e) =>
            {
                Background = background;
            };
        }
        IFunction function_Click;

        #region ISetter

        void ISetter.ISetWidth(object value)
        {
            Width = Convert.ToDouble(value);
        }

        void ISetter.ISetHeight(object value)
        {
            Height = Convert.ToDouble(value);
        }

        void ISetter.ISetHorizontalAlignment(object value)
        {
            if (value.ToString() == "center")
                HorizontalAlignment = HorizontalAlignment.Center;
            else if (value.ToString() == "left")
                HorizontalAlignment = HorizontalAlignment.Left;
            else if (value.ToString() == "right")
                HorizontalAlignment = HorizontalAlignment.Right;
            else if (value.ToString() == "stretch")
                HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        void ISetter.ISetVerticalAlignment(object value)
        {
            if (value.ToString() == "center")
                VerticalAlignment = VerticalAlignment.Center;
            else if (value.ToString() == "bottom")
                VerticalAlignment = VerticalAlignment.Bottom;
            else if (value.ToString() == "stretch")
                VerticalAlignment = VerticalAlignment.Stretch;
            else if (value.ToString() == "top")
                VerticalAlignment = VerticalAlignment.Top;

        }

        void ISetter.ISetMargin(object value)
        {
            double a1, a2, a3, a4;
            string[] vs = value.ToString().Split(',');
            a1 = Convert.ToDouble(vs[0]);
            a2 = Convert.ToDouble(vs[1]);
            a3 = Convert.ToDouble(vs[2]);
            a4 = Convert.ToDouble(vs[3]);
            Margin = new Thickness(a1, a2, a3, a4);
        }

        void ISetter.ISetVisibility(object value)
        {
            if (value.ToString() == "gone")
                Visibility = Visibility.Collapsed;
            else if (value.ToString() == "hidden")
                Visibility = Visibility.Hidden;
            else if (value.ToString() == "visible")
                Visibility = Visibility.Visible;
        }

        void ISetter.ISetText(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 text 属性");
        }

        void ISetter.ISetFontSize(object value)
        {
            label.FontSize = Convert.ToDouble(value);
        }

        void ISetter.ISetPadding(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有padding 属性");
        }

        void ISetter.ISetBackgroundColor(object value)
        {
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
        }

        void ISetter.ISetForegroundColor(object value)
        {
            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
        }


        void ISetter.ISetClickEvent(object value)
        {
            function_Click = value as IFunction;
        }


        void ISetter.ISetScrollPosition(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 scrollposition 属性");
        }

        void ISetter.ISetTogged(object value)
        {
            IsToggled = Convert.ToBoolean(value);
        }
        #endregion

        #region IGetter


        public object IGetWidth()
        {
            return Width;
        }

        public object IGetHeight()
        {
            return Height;
        }

        object IGetter.IGetHorizontalAlignment()
        {
            return HorizontalAlignment.ToString();
        }

        object IGetter.IGetVerticalAlignment()
        {
            return VerticalAlignment.ToString();
        }

        object IGetter.IGetMargin()
        {
            string s = String.Format("{0},{0},{0},{0}", Margin.Left, Margin.Top, Margin.Right, Margin.Bottom);
            return s;
        }

        object IGetter.IGetVisibility()
        {
            string s = "null";
            switch (Visibility)
            {
                case Visibility.Collapsed: s = "gone"; break;
                case Visibility.Hidden: s = "hidden"; break;
                case Visibility.Visible: s = "visible"; break;
            }
            return s;
        }

        object IGetter.IGetText()
        {
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性,"没有 text 属性");
        }

        object IGetter.IGetFontSize()
        {
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性,"没有 fontsize 属性");
        }

        object IGetter.IGetPadding()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性,"没有 padding 属性");
        }

        object IGetter.IGetBackgroundColor()
        {
            return Background.ToString();
        }

        object IGetter.IGetForegroundColor()
        {
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性,"没有 foregroundcolor 属性");
        }
        
        object IGetter.IGetScrollPosition()
        {
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性,"没有 scrollposition 属性");
        }

        object IGetter.IFindID(string id)
        {
            return id == Name ? this : null;
        }

        object IGetter.IGetTogged()
        {
            return IsToggled;
        }
        #endregion

        #region 实现Itype
        const string type = "switcher,function";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }
        static Switcher()
        {
            GType.Sign("switcher");
        }
        #endregion
        #region 实现IFunction
        public bool Iisasync { get { return false; } set { } }

        public Task<object> IAsyncRun(Hashtable xc)
        {
            throw new Exception();
        }
        object IFunction.IRun(Hashtable xc)
        {
            var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");
            Variable ret;
            switch (arrayList.Count)
            {
                case 1:
                Hashtable hashtable0 = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                hashtable0.Add("control", new Variable(this));
                hashtable0.Add("config", arrayList[0]);
                Variable v;
                Function.FuncStarter("Control.Get", hashtable0, out v);
                ret = v;
                break;

                case 2:

                Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                hashtable.Add("control", new Variable(this));
                hashtable.Add("config", arrayList[0]);
                hashtable.Add("value", arrayList[1]);
                Function.FuncStarter("Control.Set", hashtable, out var va);
                ret = new Variable(0);
                break;

                default:
                ret = new Variable(0);
                break;
            }
            return ret;
        }

        public object IGetCSValue()
        {
            return this;
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
    }
}
