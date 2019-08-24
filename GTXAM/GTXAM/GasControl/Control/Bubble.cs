
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GI;

namespace GTXAM.GasControl.Control
{
    public class Bubble : Button,IGetter ,ISetter,IFunction,IName
    {
        public object event_click;
        public Bubble()
        {

            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            Clicked += Bubble_Clicked;
        }

        private void Bubble_Clicked(object sender, EventArgs e)
        {
            



            var p = Parent;
            while (!(p is Page.Page))
            {
                p = (p as Element).Parent;
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
                        hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
                        Function.FuncStarter(function, hashtable, out Variable v);
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
                        Function.FuncStarter(function, hashtable, out Variable v);
                    }
                }
            }
        }
        #region 实现IName
        public string Name { get; set; }
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
            return HorizontalOptions.ToString();
        }

        object IGetter.IGetVerticalAlignment()
        {
            return VerticalOptions.ToString();
        }

        object IGetter.IGetMarin()
        {
            string s = String.Format("{0},{0},{0},{0}", Margin.Left, Margin.Top, Margin.Right, Margin.Bottom);
            return s;
        }

        object IGetter.IGetVisibility()
        {
            string s = "null";
            switch (IsVisible)
            {
                case false: s = "gone"; break;
                case true: s = "visible"; break;
            }
            return s;
        }

        object IGetter.IGetText()
        {
            return Text;
        }

        object IGetter.IGetFontSize()
        {
            return FontSize;
        }

        object IGetter.IGetPadding()
        {
            throw new Exception("没有 padding 属性");
        }

        object IGetter.IGetBackgroundColor()
        {
            return BackgroundColor.ToString();
        }

        object IGetter.IGetForegroundColor()
        {
            return BackgroundColor.ToString();
        }

        object IGetter.IFindID(string id)
        {

            return id == (this as IName).Name ? this : null;
        }

        object IGetter.IGetScrollPosition()
        {
            throw new Exception("没有 scrollposition 属性");
        }
        object IGetter.IGetTogged()
        {
            throw new Exception("没有 togged 属性");
        }
        #endregion

        #region 实现IFunction
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
        string IFunction.IInformation
        {
            get => "";
            set => throw new Exception();
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
                Function.FuncStarter("Control.Set", hashtable, out var v1);
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
            WidthRequest = Convert.ToDouble(value);
        }

        void ISetter.ISetHeight(object value)
        {
            HeightRequest = Convert.ToDouble(value);
        }
        void ISetter.ISetHorizontalAlignment(object value)
        {
            var view = this;
            if (value.ToString() == "center")
                view.HorizontalOptions = LayoutOptions.Center;
            else if (value.ToString() == "left")
                view.HorizontalOptions = LayoutOptions.Start;
            else if (value.ToString() == "right")
                view.HorizontalOptions = LayoutOptions.End;
            else if (value.ToString() == "stretch")
                view.HorizontalOptions = LayoutOptions.Fill;
        }

        void ISetter.ISetVerticalAlignment(object value)
        {
            var view = this;
            if (value.ToString() == "center")
                view.VerticalOptions = LayoutOptions.Center;
            else if (value.ToString() == "bottom")
                view.VerticalOptions = LayoutOptions.End;
            else if (value.ToString() == "stretch")
                view.VerticalOptions = LayoutOptions.Fill;
            else if (value.ToString() == "top")
                view.VerticalOptions = LayoutOptions.Start;

        }

        void ISetter.ISetMarin(object value)
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
            var visualElement = this;
            if (value.ToString() == "gone")
                visualElement.IsVisible = false;
            else if (value.ToString() == "hidden")
                visualElement.IsVisible = false;
            else if (value.ToString() == "visible")
                visualElement.IsVisible = true;
        }

        void ISetter.ISetText(object value)
        {
            Text = value.ToString();
        }

        void ISetter.ISetFontSize(object value)
        {
            FontSize = Convert.ToDouble(value);
        }

        void ISetter.ISetPadding(object value)
        {
            throw new Exception("没有 padding 属性");
        }

        void ISetter.ISetBackgroundColor(object value)
        {
            BackgroundColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
        }

        void ISetter.ISetForegroundColor(object value)
        {

            TextColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
        }

        void ISetter.ISetTogged(object value)
        {
            throw new Exception("没有 togged 属性");
        }

        void ISetter.ISetScrollPosition(object value)
        {
            throw new Exception("没有 scrollposition 属性");
        }

        void ISetter.ISetClickEvent(object value)
        {
            event_click = value ;
        }


        #endregion


        #region 实现IType
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



/*
 var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");

    #region 实现IType
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
     */
