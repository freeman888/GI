using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using GI;
using static GI.Function;

namespace GTWPF.GasControl.Control
{


    /// <summary>
    /// Gasoline 输入框
    /// </summary>
    public class EditText : TextBox, IOBJ
    {
        public EditText()
        {

            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
            AcceptsReturn = true;

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
                {"Text",new FVariable{
                    ongetvalue = ()=> new Gstring(Text.ToString()),
                    onsetvalue = (value)=>
                    {
                        Text = value.ToString();
                        return 0;
                    }
                } },
                {"FontSize",new FVariable{
                    ongetvalue = ()=>new Gnumber(FontSize),
                    onsetvalue = (value)=>
                    {
                        FontSize = Convert.ToDouble(value);
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
                {"Foreground",new FVariable{ ongetvalue =()=>new Gstring(Foreground.ToString()),
                onsetvalue = (value)=>
                {
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
                    return 0;
                } } },
               





            };
            parent = new GTWPF.Control(this);

            #endregion
        }


        
        public object IGetCSValue()
        {
            return this;
        }

     
        


        #region 实现Itype
        const string type = "Edittext";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }
        static EditText()
        {
            GType.Sign("Edittext");
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

        public static IOBJ GetEditTextFromXml(XmlElement xmlelement)
        {
            var edittext = new EditText();
            edittext.Name = xmlelement.GetAttribute("Name");
            //Width
            {
                var value = xmlelement.GetAttribute("Width");
                if (!string.IsNullOrEmpty(value))
                    edittext.Width = Convert.ToDouble(value);
            }
            //Height
            {
                var value = xmlelement.GetAttribute("Height");
                if (!string.IsNullOrEmpty(value))
                    edittext.Height = Convert.ToDouble(value);
            }
            //Horizontal
            {
                var value = xmlelement.GetAttribute("Horizontal");
                if (!string.IsNullOrEmpty(value))
                {

                    if (value.ToString() == "center")
                        edittext.HorizontalAlignment = HorizontalAlignment.Center;
                    else if (value.ToString() == "left")
                        edittext.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (value.ToString() == "right")
                        edittext.HorizontalAlignment = HorizontalAlignment.Right;
                    else if (value.ToString() == "stretch")
                        edittext.HorizontalAlignment = HorizontalAlignment.Stretch;
                }

            }
            //Vertical

            {

                var value = xmlelement.GetAttribute("Vertical");

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "center")
                        edittext.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        edittext.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        edittext.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        edittext.VerticalAlignment = VerticalAlignment.Top;
                }
            }
            //Margin
            {
                var value = xmlelement.GetAttribute("Margin");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    edittext.Margin = new Thickness(
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
                        edittext.Visibility = Visibility.Collapsed;
                    else if (value.ToString() == "hidden")
                        edittext.Visibility = Visibility.Hidden;
                    else if (value.ToString() == "visible")
                        edittext.Visibility = Visibility.Visible;
                }
            }
            //Text
            {
                var value = xmlelement.GetAttribute("Text");
                if (!string.IsNullOrEmpty(value))
                {
                    edittext.Text = value;
                }
            }
            //Fontsize
            {
                var value = xmlelement.GetAttribute("FontSize");
                if (!string.IsNullOrEmpty(value))
                {
                    edittext.FontSize = Convert.ToDouble(value);
                }
            }
            
            //BackGround
            {
                var value = xmlelement.GetAttribute("Background");
                if (!string.IsNullOrEmpty(value))
                    edittext.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            //Foreground
            {
                var value = xmlelement.GetAttribute("Foreground");
                if (!string.IsNullOrEmpty(value))
                    edittext.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            //Row
            {
                var value = xmlelement.GetAttribute("Row");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetRow(edittext, Convert.ToInt32(value));

            }
            //Column
            {
                var value = xmlelement.GetAttribute("Column");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetColumn(edittext, Convert.ToInt32(value));
            }
            return edittext;
        }
    }
}
