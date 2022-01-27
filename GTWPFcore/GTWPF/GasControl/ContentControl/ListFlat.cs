using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using static GI.Function;

namespace GTWPF.GasControl.ContentControl
{
    public class ListFlat : ListView, IOBJ
    {
        public ListFlat()
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

                {"Add",new Variable(new MFunction(add,this)) },
                {"Clear",new Variable(new MFunction(clear,this)) },




            };

            parent = new GTWPF.Control(this);
        }

        #region 实现IOBJ

        public object IGetCSValue()
        {
            return this;
        }
        const string type = "ListFlat";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }
        static ListFlat()
        {
            GType.Sign("ListFlat");
        }
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

        static IFunction add = new Function_Add();
        public class Function_Add : Function
        {
            public Function_Add()
            {
                str_xcname = "con";
                poslib = "Control";
            }

            public override object Run(Hashtable xc)
            {
                var listflat = xc.GetCSVariableFromSpeType<ListFlat>("this", "ListFlat");
                var con = xc.GetCSVariableFromSpeType<UIElement>("con", "Cell");

                listflat.Items.Add(con);

                return new Variable(0);
            }
        }
        static IFunction clear = new Function_Clear();
        public class Function_Clear : Function
        {
            public Function_Clear()
            {

                IInformation = "";
                str_xcname = "";
                poslib = "Control";
            }
            public override object Run(Hashtable xc)
            {
                var listflat = xc.GetCSVariableFromSpeType<ListFlat>("this", "ListLlat");
                listflat.Items.Clear();
                return new Variable(0);
            }
        }

        public static IOBJ GetListFlatFromXml(GTWPF.GasControl.Page.GasPage basepage, XmlElement xmlelement)
        {
            var listflat = new ListFlat();
            listflat.Name = xmlelement.GetAttribute("Name");
            //Width
            {
                var value = xmlelement.GetAttribute("Width");
                if (!string.IsNullOrEmpty(value))
                    listflat.Width = Convert.ToDouble(value);
            }
            //Height
            {
                var value = xmlelement.GetAttribute("Height");
                if (!string.IsNullOrEmpty(value))
                    listflat.Height = Convert.ToDouble(value);
            }
            //Horizontal
            {
                var value = xmlelement.GetAttribute("Horizontal");
                if (!string.IsNullOrEmpty(value))
                {

                    if (value.ToString() == "center")
                        listflat.HorizontalAlignment = HorizontalAlignment.Center;
                    else if (value.ToString() == "left")
                        listflat.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (value.ToString() == "right")
                        listflat.HorizontalAlignment = HorizontalAlignment.Right;
                    else if (value.ToString() == "stretch")
                        listflat.HorizontalAlignment = HorizontalAlignment.Stretch;
                }

            }
            //Vertical

            {

                var value = xmlelement.GetAttribute("Vertical");

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "center")
                        listflat.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        listflat.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        listflat.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        listflat.VerticalAlignment = VerticalAlignment.Top;
                }
            }
            //Margin
            {
                var value = xmlelement.GetAttribute("Margin");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    listflat.Margin = new Thickness(
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
                        listflat.Visibility = Visibility.Collapsed;
                    else if (value.ToString() == "hidden")
                        listflat.Visibility = Visibility.Hidden;
                    else if (value.ToString() == "visible")
                        listflat.Visibility = Visibility.Visible;
                }
            }
            //BackGround
            {
                var value = xmlelement.GetAttribute("Background");
                if (!string.IsNullOrEmpty(value))
                    listflat.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            //Row
            {
                var value = xmlelement.GetAttribute("Row");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetRow(listflat, Convert.ToInt32(value));

            }
            //Column
            {
                var value = xmlelement.GetAttribute("Column");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetColumn(listflat, Convert.ToInt32(value));
            }
            foreach (XmlNode i in xmlelement.ChildNodes)
            {
                if (i is XmlElement)
                {
                    listflat.Items.Add(GTWPF.Control.GetControlFromXmlElement(basepage, i as XmlElement).IGetCSValue() as UIElement);

                }
            }
            return listflat;
        }
    }
}
