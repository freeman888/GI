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
using System.Diagnostics;
using static GI.Function;

namespace GTWPF.GasControl.ContentControl
{


    /// <summary>
    /// Gasoline 滚动布局
    /// </summary>
    public class ScrollFlat : ScrollViewer, ISetter, IOBJ, IGetter
    {
        public ScrollFlat()
        {
            
            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            #region
            members = new Dictionary<string, Variable>
            {
                {"Width" ,new FVariable{
                    ongetvalue = ()=>new Gnumber(Width),
                    onsetvalue = (value)=>{Width =Convert.ToDouble( value); return 0; }}},
                {"Height" ,new FVariable
                {
                    ongetvalue = ()=>new Gnumber(Height),
                    onsetvalue = (value)=>{Height = Convert.ToDouble(value);return 0; }
                }},
                {"Horizontal",new FVariable
                {
                    ongetvalue = ()=> new Gstring( HorizontalAlignment.ToString()),
                    onsetvalue = (value) =>{
                        if (value.ToString() == "center")
                            HorizontalAlignment = HorizontalAlignment.Center;
                        else if (value.ToString() == "left")
                            HorizontalAlignment = HorizontalAlignment.Left;
                        else if (value.ToString() == "right")
                            HorizontalAlignment = HorizontalAlignment.Right;
                        else if (value.ToString() == "stretch")
                            HorizontalAlignment = HorizontalAlignment.Stretch;
                        return 0;
                    }
                } },
                {"Vertical",new FVariable{
                ongetvalue = ()=>new Gstring(VerticalAlignment.ToString()),
                onsetvalue = (value)=>
                {
                    if (value.ToString() == "center")
                        VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        VerticalAlignment = VerticalAlignment.Top;
                    return 0;
                }
                } },
                {"Margin",new FVariable{
                ongetvalue =() => new Glist{new Variable(Margin.Left) ,new Variable(Margin.Top),new Variable(Margin.Right),new Variable(Margin.Bottom)},
                onsetvalue = (value)=>
                {
                    var list = value.IGetCSValue() as Glist;
                    Margin = new Thickness(
                        Convert.ToDouble( list[0].value),Convert.ToDouble(list[1].value),Convert.ToDouble(list[2].value),Convert.ToDouble(list[3].value)
                          );
                    return 0;
                }

                } },
                {"Visibility",new FVariable{
                    ongetvalue = () =>
                    {
                        string s = "null";
            switch (Visibility)
            {
                case Visibility.Collapsed: s = "gone"; break;
                case Visibility.Hidden: s = "hidden"; break;
                case Visibility.Visible: s = "visible"; break;
            }
            return new Gstring(s);
                    },
                    onsetvalue = (value)=>
                    {
                        if (value.ToString() == "gone")
                Visibility = Visibility.Collapsed;
            else if (value.ToString() == "hidden")
                Visibility = Visibility.Hidden;
            else if (value.ToString() == "visible")
                Visibility = Visibility.Visible;
                        return 0;
                    }
                } },
                
               
                {"Padding" ,new FVariable{
                    ongetvalue =() => new Glist{new Variable(Padding.Left) ,new Variable(Padding.Top),new Variable(Padding.Right),new Variable(Padding.Bottom)},
                onsetvalue = (value)=>
                {
                    var list = value.IGetCSValue() as Glist;
                    Padding = new Thickness(
                        Convert.ToDouble( list[0].value),Convert.ToDouble(list[1].value),Convert.ToDouble(list[2].value),Convert.ToDouble(list[3].value)
                          );
                    return 0;
                }} },
                {"Background",new FVariable{
                    ongetvalue = ()=>new Gstring(Background.ToString()),
                    onsetvalue = (value)=>
                    {
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
                        return 0;
                    }
                } },
               

                {"ScrollPosition" ,new FVariable
                {
                    ongetvalue = ()=>
                    {
                        return new Glist
                        {
                            new Variable(ScrollInfo.HorizontalOffset),
                            new Variable(ScrollInfo.VerticalOffset)
                        };
                    },
                    onsetvalue = (value)=>
                    {
                        if(value.IGetType() == "List")
                        {
                            var list = value.IGetCSValue() as Glist;
                            var ho =Convert.ToDouble( list[0].value);
                            var vo = Convert.ToDouble(list[1].value);
                            ScrollToHorizontalOffset(ho);
                            ScrollToVerticalOffset(vo);
                        }
                        else
                        {
                            string s_info = value.ToString();
            switch (s_info)
            {
                case "bottom":
                    ScrollToBottom();
                    return 0;
                case "end":
                    ScrollToEnd();
                    return 0;
                case "home":
                    ScrollToHome();
                    return 0;
                case "leftend":
                    ScrollToLeftEnd();
                    return 0;
                case "rightend":
                    ScrollToRightEnd();
                    return 0;
                case "top":
                    ScrollToTop();
                    return 0;
                default:
                    break;
            }
                        }
                        return 0;
                    }
                } },
                {"SetContent",new Variable(new MFunction(setcontent,this)) }
                


            };
            parent = new GTWPF.Control(this);
            #endregion

        }

        #region 实现IGetter

        object IGetter.IGetScrollPosition()
        {
            return string.Format("{0},{1}", ScrollInfo.HorizontalOffset, ScrollInfo.VerticalOffset);
        }

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
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 text 属性");
        }

        object IGetter.IGetFontSize()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 fontsize 属性");
        }

        object IGetter.IGetPadding()
        {
            return string.Format("{0},{1},{2},{3}", Padding.Left, Padding.Top, Padding.Right, Padding.Bottom);
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
            if (id == Name)
                return this;
            else
            {
                var i = Content as IGetter;
                object o = i.IFindID(id);
                if (o != null)
                    return o;

                return null;
            }
        }

        object IGetter.IGetTogged()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }
        #endregion


        
        public object IGetCSValue()
        {
            return this;
        }
       
       
        #region 实现ISettet

        void ISetter.ISetScrollPosition(object value)
        {

            string s_info = value.ToString();
            switch (s_info)
            {
                case "bottom":
                    ScrollToBottom();
                    return;
                case "end":
                    ScrollToEnd();
                    return;
                case "home":
                    ScrollToHome();
                    return;
                case "leftend":
                    ScrollToLeftEnd();
                    return;
                case "rightend":
                    ScrollToRightEnd();
                    return;
                case "top":
                    ScrollToTop();
                    return;
                default:
                    break;
            }
            double ho, vo;
            var list = s_info.Split(',');
            ho = double.Parse(list[0]);
            vo = double.Parse(list[1]);
            ScrollToHorizontalOffset(ho);
            ScrollToVerticalOffset(vo);
        }

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
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "ScrollFlat 不包含 text 属性");
        }

        void ISetter.ISetFontSize(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "ScrollFlat 不包含 fontsize 属性");
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
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "此控件没有 click 事件");
        }

        void ISetter.ISetTogged(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "此控件没有 togged 事件");
            
        }

        #endregion
        #region 实现IType
        const string type = "ScrollFlat";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }



        static ScrollFlat()
        {
            GType.Sign("ScrollFlat");
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
        GTWPF.Control parent;
        public IOBJ IGetParent()
        {
            return parent;
        }

        #endregion

        //memfunction
        static IFunction setcontent = new Function_SetContent();
        public class Function_SetContent:Function
        {
            public Function_SetContent()
            {
                str_xcname = "control";
                IInformation = "";
            }

            public override object Run(Hashtable xc)
            {
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "GridFlat");
                var content = xc.GetCSVariableFromSpeType<UIElement>("control", "Control");
                
                grid.Children.Add(content);
                return new Variable(0);
            }
        }


    }
}
