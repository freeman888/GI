﻿using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GTWPF.GasControl.Control
{

    /// <summary>
    /// Gasoline 按钮
    /// </summary>
    public class Bubble : Button,ISetter,IFunction,IGetter
    {


        public object event_click;
        public Bubble()
        {
            Style = MainWindow.MainApp.BackButton.Style;
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
            Click += Bubble_Click;
            Padding = new Thickness(12, 7, 12, 7);
        }
        private async void Bubble_Click(object sender, RoutedEventArgs e)
        {
            var p = Parent;
            while(!(p is Page.GasPage))
            {
                p = (p as FrameworkElement).Parent;
            }
            if (event_click != null && p != null)
            {
                if (event_click is IFunction)
                {
                    IFunction function = event_click as IFunction;
                    Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                    string[] sss = function.Istr_xcname.Split(',');
                    if (sss.Length == 2)
                    {
                        hashtable.Add(sss[0], new Variable(p));
                        hashtable.Add(sss[1], new Variable(new Glist { new Variable(this),new Variable(e)}));
                        await Function.AsyncFuncStarter(function, hashtable);
                    }
                }
                else
                {
                    IFunction function = Variable.GetTrueVariable<IFunction>(Gasoline.sarray_Sys_Variables, event_click.ToString());
                    Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                    string[] sss = function.Istr_xcname.Split(',');
                    if (sss.Length == 2)
                    {
                        hashtable.Add(sss[0], new Variable(p));
                        hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
                        await Function.AsyncFuncStarter(function, hashtable);
                    }
                }
            }
        }
        #region 实现IFunction
        public bool Iisasync { get { return false; } set { } }

        public Task<object> IAsyncRun(Hashtable xc)
        {
            throw new Exception();
        }
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
        
public string IInformation { get => "to be added"; set => throw new NotImplementedException(); }
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
                Function.FuncStarter("Control.Set", hashtable,out var va);
                ret = new Variable(0);
                break;

                default:
                ret = new Variable(0);
                break;
            }
            return ret;
        }
        #endregion
        #region 实现ISettet


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
            Content = value.ToString();
        }

        void ISetter.ISetFontSize(object value)
        {
            FontSize = Convert.ToDouble(value);
        }

        void ISetter.ISetPadding(object value)
        {
            double a1, a2, a3, a4;
            string[] vs = value.ToString().Split(',');
            a1 = Convert.ToDouble(vs[0]);
            a2 = Convert.ToDouble(vs[1]);
            a3 = Convert.ToDouble(vs[2]);
            a4 = Convert.ToDouble(vs[3]);
            Padding = new Thickness(a1, a2, a3, a4);
        }

        void ISetter.ISetBackgroundColor(object value)
        {
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
        }

        void ISetter.ISetForegroundColor(object value)
        {
            Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
        }


        void ISetter.ISetClickEvent(object value)
        {
            event_click = value;
        }

        void ISetter.ISetScrollPosition(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 scrollposition 属性");
        }
        void ISetter.ISetTogged(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }
        #endregion
        #region 实现IGetter
        object IGetter.IGetWidth()
        {
            return Width;
        }

        object IGetter.IGetHeight()
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
            return Content.ToString();
        }

        object IGetter.IGetFontSize()
        {
            return FontSize;
        }

        object IGetter.IGetPadding()
        {
            string s = string.Format("{0},{0},{0},{0}", Padding.Left, Padding.Top, Padding.Right, Padding.Bottom);
            return s;
        }

        object IGetter.IGetBackgroundColor()
        {
            return Background.ToString();
        }

        object IGetter.IGetForegroundColor()
        {
            return Foreground.ToString();
        }
        
        object IGetter.IFindID(string id)
        {
            return id == Name ? this : null;
        }


        object IGetter.IGetScrollPosition()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 scrollposition 属性");
        }

        object IGetter.IGetTogged()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }

        #endregion

        #region 实现Itype
        const string type = "bubble,function";
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

        static Bubble()
        {
            GType.Sign("bubble");
        }
        #endregion
    }


}
