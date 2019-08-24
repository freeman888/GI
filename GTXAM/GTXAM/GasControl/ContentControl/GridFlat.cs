using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GTXAM.GasControl.Control;
using System.Collections;
using GI;

namespace GTXAM.GasControl.ContentControl
{/// <summary>
 /// Gasoline 网格布局
 /// </summary>
    public class GridFlat : Grid, IGetter, ISetter, IFunction, IName
    {
        public GridFlat()
        {

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
        }

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
            throw new Exception("没有 text 属性");
        }

        object IGetter.IGetFontSize()
        {
            throw new Exception("没有 fontsize 属性");
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
            throw new Exception("没有 foregroundcolor 属性");
        }

        object IGetter.IFindID(string id)
        {

            if (id == Name)
                return this;
            else
            {
                foreach (IGetter i in Children)
                {
                    object o = i.IFindID(id);
                    if (o != null)
                        return o;
                }
                return null;
            }
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

        #region 实现IName
        public string Name { get; set; }
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
            get => "CVF for gridflat";
            set { }
        }
        object IFunction.IRun(Hashtable xc)
        {



            var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");
            Variable ret;
            switch (arrayList.Count)
            {
                case 0:
                    {
                        ret = new Variable(new Function.DFunction
                        {
                            str_xcname = "con,row,col",
                            dRun = (dxc) =>
                            {
                                object o1 = Variable.GetTrueVariable<object>(dxc, "con");
                                object o2 = Variable.GetTrueVariable<object>(dxc, "row");
                                //object o3 = Variable.GetTrueVariable<object>(xc, "col");

                                try
                                {
                                    int i = Convert.ToInt32(o1);
                                    Hashtable dhashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                                    if (o2.ToString() == "row")
                                    {
                                        dhashtable.Add("grid", new Variable(this));
                                        dhashtable.Add("value", new Variable(i));
                                        dhashtable.Add("config", dxc["col"]);
                                        Function.FuncStarter("Control.GridFlat.SetRow", dhashtable, out var v123);
                                    }
                                    else if (o2.ToString() == "column")
                                    {
                                        dhashtable.Add("grid", new Variable(this));
                                        dhashtable.Add("value", new Variable(i));
                                        dhashtable.Add("config", dxc["col"]);
                                        Function.FuncStarter("Control.GridFlat.SetColumn", dhashtable, out var v2);
                                    }
                                }

                                catch
                                {
                                    try
                                    {
                                        Hashtable dhashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                                        dhashtable.Add("grid", new Variable(this));
                                        dhashtable.Add("control", dxc["con"]);
                                        dhashtable.Add("row", dxc["row"]);
                                        dhashtable.Add("column", dxc["col"]);
                                        Function.FuncStarter("Control.GridFlat.Add", dhashtable, out var v12);

                                    }
                                    catch
                                    { }
                                }

                                return new Variable(0);
                            }
                        });
                    }

                    break;

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
            throw new Exception("没有 text 属性");
        }

        void ISetter.ISetFontSize(object value)
        {
            throw new Exception("没有 fontsize 属性");
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


            throw new Exception("没有 foreground 属性");
        }


        void ISetter.ISetClickEvent(object value)
        {
            throw new Exception("此控件没有 click 事件");
        }


        void ISetter.ISetTogged(object value)
        {
            throw new Exception("没有 togged 属性");
        }

        void ISetter.ISetScrollPosition(object value)
        {
            throw new Exception("没有 scrollposition 属性");
        }
        #endregion
        #region 实现IType
        const string type = "gridflat,function";
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

        static GridFlat()
        {
            GType.Sign("gridflat");
        }
        #endregion
    }

}
