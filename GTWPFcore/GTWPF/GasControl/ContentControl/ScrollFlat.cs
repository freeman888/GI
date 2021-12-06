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
using GTWPF.GasControl.Page;
using System.Xml;

namespace GTWPF.GasControl.ContentControl
{


    /// <summary>
    /// Gasoline 滚动布局
    /// </summary>
    public class ScrollFlat : ScrollViewer, IOBJ
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

        internal static IOBJ GetScrollFlatFromXml(GasPage basepage, XmlElement xmlelement)
        {
            var scrollflat = new ScrollFlat();
            //Name
            scrollflat.Name = xmlelement.GetAttribute("Name");
            //Width
            {
                var value = xmlelement.GetAttribute("Width");
                if (!string.IsNullOrEmpty(value))
                    scrollflat.Width = Convert.ToDouble(value);
            }
            //Height
            {
                var value = xmlelement.GetAttribute("Height");
                if (!string.IsNullOrEmpty(value))
                    scrollflat.Height = Convert.ToDouble(value);
            }
            //Horizontal
            {
                var value = xmlelement.GetAttribute("Horizontal");
                if (!string.IsNullOrEmpty(value))
                {

                    if (value.ToString() == "center")
                        scrollflat.HorizontalAlignment = HorizontalAlignment.Center;
                    else if (value.ToString() == "left")
                        scrollflat.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (value.ToString() == "right")
                        scrollflat.HorizontalAlignment = HorizontalAlignment.Right;
                    else if (value.ToString() == "stretch")
                        scrollflat.HorizontalAlignment = HorizontalAlignment.Stretch;
                }

            }
            //Vertical

            {

                var value = xmlelement.GetAttribute("Vertical");

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "center")
                        scrollflat.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        scrollflat.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        scrollflat.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        scrollflat.VerticalAlignment = VerticalAlignment.Top;
                }
            }
            //Margin
            {
                var value = xmlelement.GetAttribute("Margin");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    scrollflat.Margin = new Thickness(
                         Convert.ToDouble(list[0]), Convert.ToDouble(list[1]), Convert.ToDouble(list[2]), Convert.ToDouble(list[3])
                           );
                }
            }
            //Visibility
            {
                var value = xmlelement.GetAttribute("Visibility");
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "gone")
                        scrollflat.Visibility = Visibility.Collapsed;
                    else if (value.ToString() == "hidden")
                        scrollflat.Visibility = Visibility.Hidden;
                    else if (value.ToString() == "visible")
                        scrollflat.Visibility = Visibility.Visible;
                }
            }
            //Padding
            {
                var value = xmlelement.GetAttribute("Padding");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    scrollflat.Padding = new Thickness(
                         Convert.ToDouble(list[0]), Convert.ToDouble(list[1]), Convert.ToDouble(list[2]), Convert.ToDouble(list[3])
                           );
                }
            }
            //BackGround
            {
                var value = xmlelement.GetAttribute("Background");
                if (!string.IsNullOrEmpty(value))
                    scrollflat.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            //Row
            {
                var value = xmlelement.GetAttribute("Row");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetRow(scrollflat, Convert.ToInt32(value));

            }
            //Column
            {
                var value = xmlelement.GetAttribute("Column");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetColumn(scrollflat, Convert.ToInt32(value));
            }
            if (xmlelement.HasChildNodes)
            {
                scrollflat.Content = GTWPF.Control.GetControlFromXmlElement(basepage, xmlelement.FirstChild as XmlElement);
            }
            return scrollflat;
        }

        public object IGetCSValue()
        {
            return this;
        }
       
       
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
                var grid = xc.GetCSVariableFromSpeType<ScrollFlat>("this", "ScrollFlat");
                var content = xc.GetCSVariableFromSpeType<UIElement>("control", "Control");

                grid.Content = content;
                return new Variable(0);
            }
        }


    }
}
