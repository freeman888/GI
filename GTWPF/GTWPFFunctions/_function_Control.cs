using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GI;
using static GI.Function;

namespace GTWPF
{
    public partial class GTWPFFunction
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
                h.Add("Control.EditText.ScrollToEnd", new EditText_Function_ScrollToEnd());
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


                #region ScrollFlat系列方法
                h.Add("Control.ScrollFlat.Creat", new ScrollFlat_Function_Creat());
                h.Add("Control.ScrollFlat.Scroll", new ScrollFlat_Function_ScrollToPosition());
                #endregion
            }

            #region 通用方法
            public class Control_Function_Set :GI. Function
            {
                public Control_Function_Set()
                {
                    IInformation = 
@"set the config of the control the value
[config(string)]:
width
height
horizontalalignment :center ,left ,right ,stretch
verticalalignment :center ,bottom ,stretch ,top
margin
visibility :gone ,hidden ,visiable
text
fontsize
padding
backgroundcolor
foregroundcolor(text color)
togged (whether the switcher is on or off)
clickevent
";
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

                        case "margin": setter.ISetMargin(value); break;

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
            public class Control_Function_Get  :GI.Function
            {
                public Control_Function_Get()
                {
                    IInformation =
@"get the config of the control the value
[config(string)]:
width
height
horizontalalignment :center ,left ,right ,stretch
verticalalignment :center ,bottom ,stretch ,top
margin
visibility :gone ,hidden ,visiable
text
fontsize
padding
backgroundcolor
foregroundcolor(text color)
togged (whether the switcher is on or off)
clickevent
";
                    str_xcname = "control,config";
                }

                public override object Run(Hashtable xc)
                {
                    GasControl.Control.IGetter setter = (GasControl.Control.IGetter)Variable.GetTrueVariable<object>(xc, "control");


                    string config = Variable.GetTrueVariable<object>(xc, "config").ToString().ToLower();

                    object ret;
                    switch (config)
                    {
                        case "width": ret = setter.IGetWidth(); break;

                        case "height": ret = setter.IGetHeight(); break;

                        case "horizontalalignment": ret = setter.IGetHorizontalAlignment(); break;

                        case "verticalalignment": ret = setter.IGetVerticalAlignment(); break;

                        case "margin": ret = setter.IGetMargin(); break;

                        case "visibility": ret = setter.IGetVisibility(); break;

                        case "text": ret = setter.IGetText(); break;

                        case "fontsize": ret = setter.IGetFontSize(); break;

                        case "padding": ret = setter.IGetPadding(); break;

                        case "backgroundcolor": ret = setter.IGetBackgroundColor(); break;

                        case "foregroundcolor": ret = setter.IGetForegroundColor(); break;

                        case "togged":ret = setter.IGetTogged();break;

                        case "scrollposition":ret = setter.IGetScrollPosition();break;

                        default: throw new Exceptions.RunException(Exceptions.EXID.无对应属性,"没有 " + config + " 属性");
                    }
                    return new Variable(ret);
                }

            }
            #endregion

            #region Bubble 系列方法

            public class Bubble_Function_Creat : GI.Function
            {
                public Bubble_Function_Creat()
                {
                    IInformation = "Creat a bubble and use the text as its name";
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
            public class Tip_Function_Creat : GI.Function
            {
                public Tip_Function_Creat()
                {

                    IInformation = "Creat a Tip and use the text as its name";
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
            public class EditText_Function_Creat : GI.Function
            {
                public EditText_Function_Creat()
                {

                    IInformation = "Creat an EditText and use the text as its name";
                    str_xcname = "text";
                }
                public override object Run(Hashtable xc)
                {
                    string text = Variable.GetTrueVariable<object>(xc, "text").ToString();
                    return new Variable(new GasControl.Control.EditText() { Name = text });
                }
            }

            public class EditText_Function_ScrollToEnd : GI.Function
            {
                public EditText_Function_ScrollToEnd()
                {
                    IInformation = "Scroll this control to end";
                    str_xcname = "text";
                }
                public override object Run(Hashtable xc)
                {
                    var text = xc.GetCSVariable<GTWPF.GasControl.Control.EditText>("text");
                    text.ScrollToEnd();
                    return new Variable(0);
                }
            }
            #endregion

            #region GridFlat系列方法
            public class GridFlat_Function_Creat : GI.Function
            {
                public GridFlat_Function_Creat()
                {
                    IInformation = "Creat a GridFlat and use the text as its name";
                    str_xcname = "text";
                }
                public override object Run(Hashtable xc)
                {
                    var t = Variable.GetTrueVariable<object>(xc, "text").ToString();
                    return new Variable(new GasControl.ContentControl.GridFlat() { Name = t });
                }
            }
            public class GridFlat_Function_SetRow : GI.Function
            {
                public GridFlat_Function_SetRow()
                {
                    IInformation = "set the row definition .\n[config(string)]:value ,rate ,auto";
                    str_xcname = "grid,value,config";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.ContentControl.GridFlat grid = Variable.GetTrueVariable<GasControl.ContentControl.GridFlat>(xc, "grid");
                    double value = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "value"));
                    string config = Variable.GetTrueVariable<object>(xc, "config").ToString();

                    if (config == "value")
                    {
                        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(value, GridUnitType.Pixel) });
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
            public class GridFlat_Function_SetColumn : GI.Function
            {
                public GridFlat_Function_SetColumn()
                {
                    IInformation = "set the column definition .\n[config(string)]:value ,rate ,auto";
                    str_xcname = "grid,value,config";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.ContentControl.GridFlat grid = Variable.GetTrueVariable<GasControl.ContentControl.GridFlat>(xc, "grid");
                    double value = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "value"));
                    string config = Variable.GetTrueVariable<object>(xc, "config").ToString();

                    if (config == "value")
                    {
                        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(value, GridUnitType.Pixel) });
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
            public class GridFlat_Function_Add : GI.Function

            {
                public GridFlat_Function_Add()
                {
                    IInformation = "add the control into the gridflat.";
                    str_xcname = "grid,control,row,column";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.ContentControl.GridFlat grid = Variable.GetTrueVariable<GasControl.ContentControl.GridFlat>(xc, "grid");
                    double row = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "row"));
                    double column = Convert.ToDouble(Variable.GetTrueVariable<object>(xc, "column"));
                    FrameworkElement control = Variable.GetTrueVariable<FrameworkElement>(xc, "control");
                    Grid.SetRow(control, Convert.ToInt32(row));
                    Grid.SetColumn(control, Convert.ToInt32(column));
                    grid.Children.Add(control);
                    return new Variable(0);
                }
            }
            #endregion

            #region Switcher 系列方法
            public class Switcher_Function_Creat: GI.Function
            {
                public Switcher_Function_Creat()
                {

                    IInformation = "Creat a Switcher and use the text as its name";
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
            public class ScrollFlat_Function_Creat:Function
            {
                public ScrollFlat_Function_Creat()
                {

                    IInformation = "Creat a ScrollFlat and use the text as its name";
                    str_xcname = "name";
                }
                public override object Run(Hashtable xc)
                {
                    GasControl.ContentControl.ScrollFlat scrollFlat = new GasControl.ContentControl.ScrollFlat();
                    scrollFlat.Name = xc.GetCSVariable<object>("name").ToString();
                    return new Variable(scrollFlat);
                }
            }
            public class ScrollFlat_Function_ScrollToPosition:Function
            {
                public ScrollFlat_Function_ScrollToPosition()
                {
                    IInformation = "scroll to the certain location.";
                    str_xcname = "scrollflat,x,y";
                }
                public override object Run(Hashtable xc)
                {
                    var scrollflat = xc.GetCSVariable<GasControl.ContentControl.ScrollFlat>("scrollflat");
                    scrollflat.ScrollToHorizontalOffset(Convert.ToDouble(xc.GetCSVariable<object>("x")));
                    scrollflat.ScrollToVerticalOffset(Convert.ToDouble(xc.GetCSVariable<object>("y")));
                    return new Variable(0);
                }
            }
            #endregion
        }
    }
}
