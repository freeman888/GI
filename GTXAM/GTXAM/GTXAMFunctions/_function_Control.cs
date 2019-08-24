using System;
using System.Collections;
using Xamarin.Forms;
using GI;
using static GI.Function;
using System.Collections.Generic;

namespace GTXAM.GTXAMFunctions
{
    public partial class GTXAMFunction
    {
        public class Control_Head : Head
        {

            public override void AddFunctions(Dictionary<string, IFunction> h)
            {
                #region 通用系列
                h.Add("Control.Set", new Control_Function_Set());
                h.Add("Control.Get", new Control_Function_Get());
                #endregion

                #region Bubble系列
                h.Add("Control.Bubble.Creat", new Bubble_Function_Creat());
                #endregion

                #region Tip系列
                h.Add("Control.Tip.Creat", new Tip_Function_Creat());
                #endregion

                #region EditText系列
                h.Add("Control.EditText.Creat", new EditText_Function_Creat());
                #endregion

                #region GridFlat系列
                h.Add("Control.GridFlat.Creat", new GridFlat_Function_Creat());
                h.Add("Control.GridFlat.SetRow", new GridFlat_Function_SetRow());
                h.Add("Control.GridFlat.SetColumn", new GridFlat_Function_SetColumn());
                h.Add("Control.GridFlat.Add", new GridFlat_Function_Add());
                #endregion

                #region Switcher 系列
                h.Add("Control.Switcher.Creat", new Switcher_Function_Creat());
                #endregion

                #region ScrollFlat 系列
                h.Add("Control.ScrollFlat.Creat",new ScrollFlat_Function_Creat());
                h.Add("Control.ScrollFlat.Scroll",new ScrollFlat_Function_ScrollToPosition());
                #endregion
            }

            #region 通用方法
            public class Control_Function_Set : Function
            {
                public Control_Function_Set()
                {
                    str_xcname = "control,config,value";
                }

                public override object Run(Hashtable xc)
                {
                    GasControl.Control.ISetter setter = (GasControl.Control.ISetter)Variable.GetTrueVariable<object>(xc, "control");


                    string config = Variable.GetTrueVariable<object>(xc, "config").ToString().ToLower();
                    object value = Variable.GetTrueVariable<object>(xc, "value");

                    switch (config)
                    {
                        case "width": setter.ISetWidth(value); break;

                        case "height": setter.ISetHeight(value); break;

                        case "horizontalalignment": setter.ISetHorizontalAlignment(value); break;

                        case "verticalalignment": setter.ISetVerticalAlignment(value); break;

                        case "margin": setter.ISetMarin(value); break;

                        case "visibility": setter.ISetVisibility(value); break;

                        case "text": setter.ISetText(value); break;

                        case "fontsize": setter.ISetFontSize(value); break;

                        case "padding": setter.ISetPadding(value); break;

                        case "backgroundcolor": setter.ISetBackgroundColor(value); break;

                        case "foregroundcolor": setter.ISetForegroundColor(value); break;

                        case "togged": setter.ISetTogged(value);break;

                        case "scrollposition":setter.ISetScrollPosition(value);break;


                        case "clickevent": setter.ISetClickEvent(value); break;

                    }
                    return new Variable(setter);
                }

            }
            public class Control_Function_Get : Function
            {
                public Control_Function_Get()
                {
                    str_xcname = "control,config";
                }

                public override object Run(Hashtable xc)
                {
                    GasControl.Control.IGetter getter = (GasControl.Control.IGetter)Variable.GetTrueVariable<object>(xc, "control");


                    string config = Variable.GetTrueVariable<object>(xc, "config").ToString().ToLower();

                    object ret;
                    switch (config)
                    {
                        case "width": ret = getter.IGetWidth(); break;

                        case "height": ret = getter.IGetHeight(); break;

                        case "horizontalalignment": ret = getter.IGetHorizontalAlignment(); break;

                        case "verticalalignment": ret = getter.IGetVerticalAlignment(); break;

                        case "margin": ret = getter.IGetMarin(); break;

                        case "visibility": ret = getter.IGetVisibility(); break;

                        case "text": ret = getter.IGetText(); break;

                        case "fontsize": ret = getter.IGetFontSize(); break;

                        case "padding": ret = getter.IGetPadding(); break;

                        case "backgroundcolor": ret = getter.IGetBackgroundColor(); break;

                        case "foregroundcolor": ret = getter.IGetForegroundColor(); break;

                        case "togged":ret = getter.IGetTogged();break;

                        case "scrollposition": ret = getter.IGetScrollPosition();break;


                        default: throw new Exception("没有 " + config + " 属性");
                    }
                    return new Variable(ret);
                }

            }
            #endregion

            #region Bubble 系列方法

            public class Bubble_Function_Creat : Function
            {
                public Bubble_Function_Creat()
                {
                    str_xcname = "text";
                }
                public override object Run(Hashtable xc)
                {
                    string text = Variable.GetTrueVariable<object>(xc, "text").ToString();
                    return new Variable(new GasControl.Control.Bubble() { Name = text });
                }
            }
            #endregion

            #region Tip系列方法
            public class Tip_Function_Creat : Function
            {
                public Tip_Function_Creat()
                {
                    str_xcname = "text";
                }
                public override object Run(Hashtable xc)
                {
                    string text = Variable.GetTrueVariable<object>(xc, "text").ToString();
                    return new Variable(new GasControl.Control.Tip() { Name = text });
                }
            }
            #endregion

            #region EditText系列方法
            public class EditText_Function_Creat : Function
            {
                public EditText_Function_Creat()
                {
                    str_xcname = "text";
                }
                public override object Run(Hashtable xc)
                {
                    string text = Variable.GetTrueVariable<object>(xc, "text").ToString();
                    return new Variable(new GasControl.Control.EditText() { Name = text });
                }
            }
            #endregion

            #region GridFlat系列方法
            public class GridFlat_Function_Creat : Function
            {
                public GridFlat_Function_Creat()
                {
                    str_xcname = "text";
                }
                public override object Run(Hashtable xc)
                {
                    var t = Variable.GetTrueVariable<object>(xc, "text").ToString();
                    return new Variable(new GasControl.ContentControl.GridFlat() { Name = t });
                }
            }
            public class GridFlat_Function_SetRow : Function
            {
                public GridFlat_Function_SetRow()
                {
                    str_xcname = "grid,value,config";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.ContentControl.GridFlat grid = Variable.GetTrueVariable<GasControl.ContentControl.GridFlat>(xc, "grid");
                    double value = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "value"));
                    string config = Variable.GetTrueVariable<object>(xc, "config").ToString();

                    if (config == "value")
                    {
                        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(value, GridUnitType.Absolute) });
                    }
                    else if (config == "rate")
                    {
                        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(value, GridUnitType.Star) });
                    }
                    else if (config == "auto")
                    {
                        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(value, GridUnitType.Auto) });
                    }

                    return new Variable(0);
                }
            }
            public class GridFlat_Function_SetColumn : Function
            {
                public GridFlat_Function_SetColumn()
                {
                    str_xcname = "grid,value,config";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.ContentControl.GridFlat grid = Variable.GetTrueVariable<GasControl.ContentControl.GridFlat>(xc, "grid");
                    double value = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "value"));
                    string config = Variable.GetTrueVariable<object>(xc, "config").ToString();

                    if (config == "value")
                    {
                        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(value, GridUnitType.Absolute) });
                    }
                    else if (config == "rate")
                    {
                        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(value, GridUnitType.Star) });
                    }
                    else if (config == "auto")
                    {
                        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(value, GridUnitType.Auto) });
                    }

                    return new Variable(0);
                }
            }
            public class GridFlat_Function_Add : Function

            {
                public GridFlat_Function_Add()
                {
                    str_xcname = "grid,control,row,column";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.ContentControl.GridFlat grid = Variable.GetTrueVariable<GasControl.ContentControl.GridFlat>(xc, "grid");
                    double row = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "row"));
                    double column = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "column"));
                    View control = Variable.GetTrueVariable<View>(xc, "control");
                    Grid.SetRow(control, Convert.ToInt32(row));
                    Grid.SetColumn(control, Convert.ToInt32(column));
                    grid.Children.Add(control);
                    return new Variable(0);
                }
            }
            #endregion

            #region Switcher 系列方法
            public class Switcher_Function_Creat : Function
            {
                public Switcher_Function_Creat()
                {
                    str_xcname = "name";
                }

                public override object Run(Hashtable xc)
                {
                    GasControl.Control.Switcher switcher = new GasControl.Control.Switcher();
                    switcher.Name = Variable.GetTrueVariable<object>(xc, "name").ToString();
                    return new Variable(switcher);
                }
            }
            #endregion

            #region ScrollFlat系列方法
            public class ScrollFlat_Function_Creat : Function
            {
                public ScrollFlat_Function_Creat()
                {
                    str_xcname = "name";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.ContentControl.ScrollFlat scrollFlat = new GasControl.ContentControl.ScrollFlat();
                    scrollFlat.Name = xc.GetCSVariable<object>("name").ToString();
                    return new Variable(scrollFlat);
                }
            }
            public class ScrollFlat_Function_ScrollToPosition : Function
            {
                public ScrollFlat_Function_ScrollToPosition()
                {
                    str_xcname = "scrollflat,x,y";
                }
                public override object Run(Hashtable xc)
                {
                    var scrollflat = xc.GetCSVariable<GasControl.ContentControl.ScrollFlat>("scrollflat");
                    scrollflat.ScrollToAsync(Convert.ToDouble(xc.GetCSVariable<object>("x")), Convert.ToDouble(xc.GetCSVariable<object>("y")), true);
                    return new Variable(0);
                }
            }
            #endregion
        }
    }
    
   
}
