using GTWPF.GasControl.Control;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Collections;
using GI;
using System.Threading.Tasks;

namespace GTWPF.GasControl.ContentControl
{

    public interface IContentControl
    {

    }

    /// <summary>
    /// Gasoline 网格布局
    /// </summary>
    public class GridFlat : Grid, IContentControl, ISetter,IFunction,IGetter
    {
        
        public GridFlat()
        {

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
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性 , "没有 text 属性");
        }

        object IGetter.IGetFontSize()
        {
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性,"没有 fontsize 属性");
        }

        object IGetter.IGetPadding()
        {
            
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性,"没有 padding 属性");
        }

        object IGetter.IGetBackgroundColor()
        {
            return Background.ToString();
        }

        object IGetter.IGetForegroundColor()
        {
            
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性,"没有 foregroundcolor 属性");
        }

        object IGetter.IFindID(string id)
        {
            if (id == Name)
                return this;
            else
            {
                foreach(IGetter i in Children)
                {
                    object o = i.IFindID(id);
                    if (o != null)
                        return o;
                }
                return null;
            }
        }

        public object IGetScrollPosition()
        {
            throw new Exceptions.RunException( Exceptions.EXID.无对应属性,"没有 scrollposition 属性");
        }

        object IGetter.IGetTogged()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }
        #endregion



        #region 实现IFunction
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
        public object IGetCSValue()
        {
            return this;
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
                            dRun = (dxc)=>
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
                                        Function.FuncStarter("Control.GridFlat.SetRow", dhashtable,out var vari);
                                    }
                                    else if (o2.ToString() == "column")
                                    {
                                        dhashtable.Add("grid", new Variable(this));
                                        dhashtable.Add("value", new Variable(i));
                                        dhashtable.Add("config", dxc["col"]);
                                        Function.FuncStarter("Control.GridFlat.SetColumn", dhashtable,out var varia);
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
                                        Function.FuncStarter("Control.GridFlat.Add", dhashtable,out var vari);

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
            throw new  Exceptions.RunException(Exceptions.EXID.无对应属性, "GridFlat 不包含 text 属性");
        }

        void ISetter.ISetFontSize(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "GridFlat 不包含 fontsize 属性");
        }

        void ISetter.ISetPadding(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "GridFlat 不包含 padding 属性");
        }

        void ISetter.ISetBackgroundColor(object value)
        {
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
        }

        void ISetter.ISetForegroundColor(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "GridFlat 不包含 foreground 属性");
        }

        void ISetter.ISetClickEvent(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "此控件没有 click 事件");
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
        static GridFlat()
        {
            GType.Sign("gridflat");
        }
        #endregion
    }
}
