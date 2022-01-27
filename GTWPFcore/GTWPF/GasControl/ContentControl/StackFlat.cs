using GI;
using GTWPF.GasControl.Page;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace GTWPF.GasControl.ContentControl
{
    public class StackFlat : StackPanel, IOBJ
    {


        public StackFlat()
        {
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



                {"Background",new FVariable{
                    ongetvalue = ()=>new Gstring(Background.ToString()),
                    onsetvalue = (value)=>
                    {
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
                        return 0;
                    }
                } },
                {"Orientation",new FVariable
                    {
                        ongetvalue = ()=>new Gstring(Orientation == Orientation.Horizontal?"horizontal":"veritical"),
                        onsetvalue = (value)=>
                        {
                            Orientation = value.ToString() == "horizontal" ? Orientation.Horizontal: Orientation.Vertical;
                            return 0;
                        }
                    }
                },
                {"Add",new Variable(new GI.Function.MFunction(add,this)) },
            };

            parent = new GTWPF.Control(this);
        }

        internal static IOBJ GetStackFlatFromXml(GasPage basepage, XmlElement xmlelement)
        {
            var stackflat = new StackFlat();
            //Name
            stackflat.Name = xmlelement.GetAttribute("Name");
            //Width
            {
                var value = xmlelement.GetAttribute("Width");
                if (!string.IsNullOrEmpty(value))
                    stackflat.Width = Convert.ToDouble(value);
            }
            //Height
            {
                var value = xmlelement.GetAttribute("Height");
                if (!string.IsNullOrEmpty(value))
                    stackflat.Height = Convert.ToDouble(value);
            }
            //Horizontal
            {
                var value = xmlelement.GetAttribute("Horizontal");
                if (!string.IsNullOrEmpty(value))
                {

                    if (value.ToString() == "center")
                        stackflat.HorizontalAlignment = HorizontalAlignment.Center;
                    else if (value.ToString() == "left")
                        stackflat.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (value.ToString() == "right")
                        stackflat.HorizontalAlignment = HorizontalAlignment.Right;
                    else if (value.ToString() == "stretch")
                        stackflat.HorizontalAlignment = HorizontalAlignment.Stretch;
                }

            }
            //Vertical

            {

                var value = xmlelement.GetAttribute("Vertical");

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "center")
                        stackflat.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        stackflat.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        stackflat.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        stackflat.VerticalAlignment = VerticalAlignment.Top;
                }
            }
            //Margin
            {
                var value = xmlelement.GetAttribute("Margin");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    stackflat.Margin = new Thickness(
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
                        stackflat.Visibility = Visibility.Collapsed;
                    else if (value.ToString() == "hidden")
                        stackflat.Visibility = Visibility.Hidden;
                    else if (value.ToString() == "visible")
                        stackflat.Visibility = Visibility.Visible;
                }
            }
            //BackGround
            {
                var value = xmlelement.GetAttribute("Background");
                if (!string.IsNullOrEmpty(value))
                    stackflat.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            //Orientation
            {
                var value = xmlelement.GetAttribute("Orientation");
                if (!string.IsNullOrEmpty(value))
                    stackflat.Orientation = value.ToString() == "horizontal" ? Orientation.Horizontal : Orientation.Vertical;

            }
            //Row
            {
                var value = xmlelement.GetAttribute("Row");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetRow(stackflat, Convert.ToInt32(value));

            }
            //Column
            {
                var value = xmlelement.GetAttribute("Column");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetColumn(stackflat, Convert.ToInt32(value));
            }
            foreach (XmlNode i in xmlelement.ChildNodes)
            {
                if (i is XmlElement)
                {
                    stackflat.Children.Add(GTWPF.Control.GetControlFromXmlElement(basepage, i as XmlElement).IGetCSValue() as UIElement);
                }
            }
            return stackflat;
        }

        static IFunction add = new StackFlat_Function_Add();
        public class StackFlat_Function_Add : Function
        {
            public StackFlat_Function_Add()
            {

                IInformation = "add a control to this stackflat";
                str_xcname = "control";
            }
            public override object Run(Hashtable xc)
            {
                var stackflat = xc.GetCSVariableFromSpeType<StackFlat>("this", "StackFlat");
                var control = xc.GetCSVariableFromSpeType<UIElement>("control", "Control");
                stackflat.Children.Add(control);
                return new Variable(0);
            }
        }

        #region 实现IType
        const string type = "StackFlat";
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



        static StackFlat()
        {
            GType.Sign("StackFlat");
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


    }
}
