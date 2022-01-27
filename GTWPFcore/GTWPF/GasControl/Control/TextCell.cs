using GI;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace GTWPF.GasControl.Control
{
    public class TextCell : StackPanel, IOBJ, IGasObjectContainer
    {
        public object event_click;
        Label text, detail;
        public TextCell()
        {
            text = new Label { Padding = new Thickness(3), FontSize = 16, HorizontalAlignment = HorizontalAlignment.Stretch };
            detail = new Label { Padding = new Thickness(3), HorizontalAlignment = HorizontalAlignment.Stretch };
            this.Children.Add(text);
            this.Children.Add(detail);

            MouseUp += TextCell_MouseDown;
            #region
            members = new Dictionary<string, Variable>
            {
              {"Text",new FVariable{
                    ongetvalue = ()=> new Gstring(text.Content.ToString()),
                    onsetvalue = (value)=>
                    {
                        text.Content = value.ToString();
                        return 0;
                    }
                } },
                {"Detail",new FVariable{ ongetvalue = ()=> new Gstring(detail.Content.ToString()), onsetvalue = (value) =>
                {
                    detail.Content = value.ToString();
                    return 0;
                }
                } },
                {"DetailColor",new FVariable
                {
                    ongetvalue = ()=>new Gstring( detail.Foreground.ToString()),
                    onsetvalue = (value)=>
                    {
                        detail.Foreground =(Brush) new BrushConverter().ConvertFromString(value.ToString());
                        return 0;
                    }
                } },
               {"Foreground",new FVariable{ ongetvalue =()=>new Gstring(text.Foreground.ToString()),
                onsetvalue = (value)=>
                {
                    text.Foreground =(Brush) new BrushConverter().ConvertFromString(value.ToString());
                    return 0;
                } } },
                {"Clickevent",new FVariable
                {
                    ongetvalue = ()=>event_click as IOBJ
                    ,onsetvalue = (value)=>
                    {
                        event_click = value;
                        return 0;
                    }
                } }





            };
            parent = new GasControl.Cell.Cell(this);
            #endregion
        }

        private async void TextCell_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var p = Parent;
            while (!(p is Page.GasPage))
            {
                p = (p as FrameworkElement).Parent;
            }
            if (event_click != null && p != null)
            {

                IFunction function = event_click as IFunction;
                string[] sss = function.Istr_xcname.Split(',');
                if (sss.Length == 2)
                {
                    await Function.NewAsyncFuncStarter(function, new Variable(p), new Variable(new Glist { new Variable(GetGasObject()), new Variable(e) }));
                }

            }
        }


        #region 实现IType
        const string type = "TextCell";
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

        static TextCell()
        {
            GType.Sign("TextCell");
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

        Cell.Cell parent;
        public IOBJ IGetParent()
        {
            return parent;
        }

        #endregion

        public static IOBJ GetTextCellFromXml(XmlElement xmlelement)
        {
            var textcell = new TextCell();
            textcell.Name = xmlelement.GetAttribute("Name");
            //Text
            {
                var value = xmlelement.GetAttribute("Text");
                if (!string.IsNullOrEmpty(value))
                {
                    textcell.text.Content = value;
                }
            }
            //Foreground
            {
                var value = xmlelement.GetAttribute("Foreground");
                if (!string.IsNullOrEmpty(value))
                    textcell.text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            //Detail
            {
                var value = xmlelement.GetAttribute("Detail");
                if (!string.IsNullOrEmpty(value))
                    textcell.detail.Content = value;

            }
            //DetailColor
            {
                var value = xmlelement.GetAttribute("DetailColor");
                if (!string.IsNullOrEmpty(value))
                    textcell.detail.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));

            }
            return textcell;

        }

        GClass gclass = null;
        public void SetGasObject(GClass gClass)
        {
            this.gclass = gClass;
        }
        public IOBJ GetGasObject()
        {
            if (gclass == null) return this;
            else return gclass;
        }
    }
}
