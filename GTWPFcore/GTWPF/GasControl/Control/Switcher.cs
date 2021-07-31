using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Collections;
using GI;
using System.Threading.Tasks;
using System.Xml;

namespace GTWPF.GasControl.Control
{
    public class Switcher : StackPanel, IOBJ,IGasObjectContainer
    {
        private bool istoggled = false;

        public bool IsToggled
        {
            get
            {
                return istoggled;
            }
            set
            {
                istoggled = value;
                pic.Source = value ? on : off;
                label.Content = value ? "on" : "off";
            }
        }

        public string Istr_xcname { get => "params"; set => throw new Exception(); }
        public bool Iisreffunction { get => false; set => throw new Exception(); }
        public string IInformation { get => "to be added"; set => throw new Exception(); }

        static BitmapImage on = new BitmapImage(new Uri(@"pack://application:,,,/GTWPF;component/GasControl/Control/SwitcherRes/on.png")), off = new BitmapImage(new Uri(@"pack://application:,,,/GTWPF;component/GasControl/Control/SwitcherRes/off.png"));
        private Image pic = new Image() { Source = on, VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, Margin = new System.Windows.Thickness(1) };
        Brush background = Brushes.Transparent;
        private Label label;
        public Switcher()
        {
            HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Height = 30;
            Orientation = Orientation.Horizontal;
            label = new Label() { VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Center, Margin = new System.Windows.Thickness(1) };
            IsToggled = false;
            Children.Add(pic);
            Children.Add(label);

            MouseDown += async (s, e) =>
            {
                IsToggled = !IsToggled;

                if (event_click == null)
                    return;
                var p = Parent;
                while (!(p is Page.GasPage))
                {
                    p = (p as FrameworkElement).Parent;
                }
                string[] sss = event_click.Istr_xcname.Split(',');
                if (sss.Length == 2)
                {
                    await Function.NewAsyncFuncStarter(event_click,new Variable(p), new Variable(new Glist { new Variable(gclass), new Variable(e) }));
                }
            };

            MouseEnter += (s, e) =>
            {
                Background = new BrushConverter().ConvertFromString("#10000000") as Brush;
            };

            MouseLeave += (s, e) =>
            {
                Background = background;
            };
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



                {"Background",new FVariable{
                    ongetvalue = ()=>new Gstring(Background.ToString()),
                    onsetvalue = (value)=>
                    {
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
                        return 0;
                    }
                } },

                {"Togged",new FVariable
                {
                    ongetvalue = ()=>new Gbool(IsToggled),
                    onsetvalue = (value)=>{IsToggled =Convert.ToBoolean( value.IGetCSValue());return 0; }
                } },
                {"Clickevent",new FVariable
                {
                    ongetvalue = ()=>event_click as IOBJ,
                    onsetvalue = (value)=>
                    {
                        event_click = value as IFunction;
                        return 0;
                    }
                } }







            };
            parent = new GTWPF.Control(this);
            #endregion
        }
        IFunction event_click;


        #region 实现Itype
        const string type = "switcher";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }
        static Switcher()
        {
            GType.Sign("switcher");
        }
        #endregion

        public object IGetCSValue()
        {
            return this;
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

        public static IOBJ GetSwitcherFromXml(XmlElement xmlelement)
        {
            Switcher switcher = new Switcher();
            switcher.Name = xmlelement.GetAttribute("Name");
            //Width
            {
                var value = xmlelement.GetAttribute("Width");
                if (!string.IsNullOrEmpty(value))
                    switcher.Width = Convert.ToDouble(value);
            }
            //Height
            {
                var value = xmlelement.GetAttribute("Height");
                if (!string.IsNullOrEmpty(value))
                    switcher.Height = Convert.ToDouble(value);
            }
            //Horizontal
            {
                var value = xmlelement.GetAttribute("Horizontal");
                if (!string.IsNullOrEmpty(value))
                {

                    if (value.ToString() == "center")
                        switcher.HorizontalAlignment = HorizontalAlignment.Center;
                    else if (value.ToString() == "left")
                        switcher.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (value.ToString() == "right")
                        switcher.HorizontalAlignment = HorizontalAlignment.Right;
                    else if (value.ToString() == "stretch")
                        switcher.HorizontalAlignment = HorizontalAlignment.Stretch;
                }

            }
            //Vertical

            {

                var value = xmlelement.GetAttribute("Vertical");

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "center")
                        switcher.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        switcher.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        switcher.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        switcher.VerticalAlignment = VerticalAlignment.Top;
                }
            }
            //Margin
            {
                var value = xmlelement.GetAttribute("Margin");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    switcher.Margin = new Thickness(
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
                        switcher.Visibility = Visibility.Collapsed;
                    else if (value.ToString() == "hidden")
                        switcher.Visibility = Visibility.Hidden;
                    else if (value.ToString() == "visible")
                        switcher.Visibility = Visibility.Visible;
                }
            }
            
            
            //BackGround
            {
                var value = xmlelement.GetAttribute("Background");
                if (!string.IsNullOrEmpty(value))
                    switcher.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            //Togged
            {
                var value = xmlelement.GetAttribute("Togged");
                if(!string.IsNullOrEmpty(value))
                {
                    switcher.IsToggled = Convert.ToBoolean(value);
                }

            }
            //Row
            {
                var value = xmlelement.GetAttribute("Row");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetRow(switcher, Convert.ToInt32(value));

            }
            //Column
            {
                var value = xmlelement.GetAttribute("Column");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetColumn(switcher, Convert.ToInt32(value));
            }
            return switcher;
        }

        GClass gclass;
        public void SetGasObject(GClass gClass)
        {
            this.gclass = gClass;
        }
    }

}
