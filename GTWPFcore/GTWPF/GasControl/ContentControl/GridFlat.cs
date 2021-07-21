using GTWPF.GasControl.Control;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Collections;
using GI;
using static GI.Function;
using System.Xml;

namespace GTWPF.GasControl.ContentControl
{

   

    /// <summary>
    /// Gasoline 网格布局
    /// </summary>
    public class GridFlat : Grid,IOBJ
    {

        public GridFlat()
        {
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

                {"Add",new Variable(new MFunction(add,this)) },
                {"AddRow",new Variable(new MFunction(addrow,this)) },
                {"AddColumn",new Variable(new MFunction(addcolume,this)) }




            };
            
            parent = new GTWPF.Control(this);
            #endregion
        }




       
        public object IGetCSValue()
        {
            return this;
        }
       



        #region 实现IType
        const string type = "gridflat";
        public string IGetType()
        {
            return type;
        }
        public override string ToString()
        {
            return IGetType();
        }
        static GridFlat()
        {
            GType.Sign("gridflat");
        }
        #endregion

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

        //memfunction

        static IFunction add = new Function_Add();
        public class Function_Add:Function
        {
            public Function_Add()
            {
                str_xcname = "con,row,column";
                poslib = "Control";
            }

            public override object Run(Hashtable xc)
            {
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "gridflat");
                var con = xc.GetCSVariableFromSpeType<UIElement>("con", "control");
                var row = Convert.ToInt32( xc.GetCSVariable<object>("row"));
                var column =Convert.ToInt32( xc.GetCSVariable<object>("column"));
                SetRow(con, row);
                SetColumn(con, column);
                grid.Children.Add(con);
                return new Variable(0);
            }
        }

        static IFunction addrow = new Function_AddRow();
        public class Function_AddRow:Function
        {
            public Function_AddRow()
            {
                str_xcname = "value,config";
                poslib = "Control";

            }
            public override object Run(Hashtable xc)

            {
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "gridflat");
                var value = Convert.ToDouble(xc.GetCSVariable<object>("value"));
                var config = xc.GetCSVariable<object>("config").ToString();
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

        static IFunction addcolume = new Function_AddColumn();
        public class Function_AddColumn : GI.Function
        {
            public Function_AddColumn()
            {
                IInformation = "set the column definition .\n[config(string)]:value ,rate ,auto";
                str_xcname = "value,config";
            }
            public override object Run(Hashtable xc)
            {
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "gridflat");
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


        public static IOBJ GetGridFlatFromXml(GTWPF.GasControl.Page.GasPage basepage, XmlElement xmlelement)
        {
            var gridflat = new GridFlat();
            gridflat.Name = xmlelement.GetAttribute("Name");
            //Width
            {
                var value = xmlelement.GetAttribute("Width");
                if (!string.IsNullOrEmpty(value))
                    gridflat.Width = Convert.ToDouble(value);
            }
            //Height
            {
                var value = xmlelement.GetAttribute("Height");
                if (!string.IsNullOrEmpty(value))
                    gridflat.Height = Convert.ToDouble(value);
            }
            //Horizontal
            {
                var value = xmlelement.GetAttribute("Horizontal");
                if (!string.IsNullOrEmpty(value))
                {

                    if (value.ToString() == "center")
                        gridflat.HorizontalAlignment = HorizontalAlignment.Center;
                    else if (value.ToString() == "left")
                        gridflat.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (value.ToString() == "right")
                        gridflat.HorizontalAlignment = HorizontalAlignment.Right;
                    else if (value.ToString() == "stretch")
                        gridflat.HorizontalAlignment = HorizontalAlignment.Stretch;
                }

            }
            //Vertical

            {

                var value = xmlelement.GetAttribute("Vertical");

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "center")
                        gridflat.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        gridflat.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        gridflat.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        gridflat.VerticalAlignment = VerticalAlignment.Top;
                }
            }
            //Margin
            {
                var value = xmlelement.GetAttribute("Margin");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    gridflat.Margin = new Thickness(
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
                        gridflat.Visibility = Visibility.Collapsed;
                    else if (value.ToString() == "hidden")
                        gridflat.Visibility = Visibility.Hidden;
                    else if (value.ToString() == "visible")
                        gridflat.Visibility = Visibility.Visible;
                }
            }
            //BackGround
            {
                var value = xmlelement.GetAttribute("Background");
                if (!string.IsNullOrEmpty(value))
                    gridflat.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            //Row
            {
                var value = xmlelement.GetAttribute("Row");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetRow(gridflat, Convert.ToInt32(value));

            }
            //Column
            {
                var value = xmlelement.GetAttribute("Column");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetColumn(gridflat, Convert.ToInt32(value));
            }
            //RowDef
            {
                var value = xmlelement.GetAttribute("RowDef");
                if(!string.IsNullOrEmpty(value))
                {
                    var l1 = value.Split(';');
                    foreach(var item in l1)
                    {
                        var l2 = item.Split(':');
                        var v = Convert.ToDouble(l2[0]);
                        var config = l2[1];
                        if (config == "value")
                        {
                            gridflat.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(v, GridUnitType.Pixel) });
                        }
                        else if (config == "rate")
                        {
                            gridflat.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(v, GridUnitType.Star) });
                        }
                        else if (config == "auto")
                        {
                            gridflat.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(v, GridUnitType.Auto) });
                        }
                    }
                }
            }
            //ColumnDef
            {
                var value = xmlelement.GetAttribute("ColumnDef");
                if (!string.IsNullOrEmpty(value))
                {
                    var l1 = value.Split(';');
                    foreach (var item in l1)
                    {
                        var l2 = item.Split(':');
                        var v = Convert.ToDouble(l2[0]);
                        var config = l2[1];
                        if (config == "value")
                        {
                            gridflat.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(v, GridUnitType.Pixel) });
                        }
                        else if (config == "rate")
                        {
                            gridflat.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(v, GridUnitType.Star) });
                        }
                        else if (config == "auto")
                        {
                            gridflat.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(v, GridUnitType.Auto) });
                        }
                    }
                }
            }
            foreach(XmlNode i in xmlelement.ChildNodes)
            {
                if(i is XmlElement)
                {
                    gridflat.Children.Add(GTWPF.Control.GetControlFromXmlElement(basepage, i as XmlElement).IGetCSValue() as UIElement);
                }
            }
            return gridflat;

        }

    }
}
