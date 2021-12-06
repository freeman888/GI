using GI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace GTWPF.GasControl.Control
{
   public class Image:System.Windows.Controls.Image,IOBJ
    {

        public Image()
        {
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
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
                {"Source" ,new FVariable{
                    ongetvalue = ()=>new GStream((System.IO.Stream) new ImageSourceConverter().ConvertTo(Source,typeof(System.IO.Stream))),
                    onsetvalue = (value) =>
                    {
                        try
                        {
                            Source = (ImageSource)new ImageSourceConverter().ConvertFrom(value.IGetCSValue());
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        return 0;
                    }
                } },

                
            };
            parent = new GTWPF.Control(this);
            #endregion
        }



        #region 实现Itype
        const string type = "Image";
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

        static Image()
        {
            GType.Sign("Image");
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

        public static IOBJ GetImageFromXml(XmlElement xmlelement)
        {
            var image = new Image();
            image.Name = xmlelement.GetAttribute("Name");
            //Width
            {
                var value = xmlelement.GetAttribute("Width");
                if (!string.IsNullOrEmpty(value))
                    image.Width = Convert.ToDouble(value);
            }
            //Height
            {
                var value = xmlelement.GetAttribute("Height");
                if (!string.IsNullOrEmpty(value))
                    image.Height = Convert.ToDouble(value);
            }
            //Horizontal
            {
                var value = xmlelement.GetAttribute("Horizontal");
                if (!string.IsNullOrEmpty(value))
                {

                    if (value.ToString() == "center")
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                    else if (value.ToString() == "left")
                        image.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (value.ToString() == "right")
                        image.HorizontalAlignment = HorizontalAlignment.Right;
                    else if (value.ToString() == "stretch")
                        image.HorizontalAlignment = HorizontalAlignment.Stretch;
                }

            }
            //Vertical

            {

                var value = xmlelement.GetAttribute("Vertical");

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "center")
                        image.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        image.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        image.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        image.VerticalAlignment = VerticalAlignment.Top;
                }
            }
            //Margin
            {
                var value = xmlelement.GetAttribute("Margin");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    image.Margin = new Thickness(
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
                        image.Visibility = Visibility.Collapsed;
                    else if (value.ToString() == "hidden")
                        image.Visibility = Visibility.Hidden;
                    else if (value.ToString() == "visible")
                        image.Visibility = Visibility.Visible;
                }
            }
            //Row
            {
                var value = xmlelement.GetAttribute("Row");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetRow(image, Convert.ToInt32(value));

            }
            //Column
            {
                var value = xmlelement.GetAttribute("Column");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetColumn(image, Convert.ToInt32(value));
            }
            return image;
            
        }
    }
}
