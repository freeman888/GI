using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui; using Microsoft.Maui.Controls;
using GTXAM.GasControl.Control;
using System.Collections;
using GI;
using System.Threading.Tasks;
using static GI.Function;
using Microsoft.Maui.Graphics.Converters;
using Microsoft.Maui.Graphics;

namespace GTXAM.GasControl.ContentControl
{/// <summary>
 /// Gasoline 网格布局
 /// </summary>
    public class GridFlat : Grid, IOBJ, IName
    {
        public GridFlat()
        {
            
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;

            #region
            members = new Dictionary<string, Variable>
            {
                {"Width" ,new FVariable{
                    ongetvalue = ()=>new Gnumber(Width),
                    onsetvalue = (value)=>{WidthRequest =Convert.ToDouble( value); return 0; }}},
                {"Height" ,new FVariable
                {
                    ongetvalue = ()=>new Gnumber(Height),
                    onsetvalue = (value)=>{HeightRequest = Convert.ToDouble(value);return 0; }
                }},
                {"Horizontal",new FVariable
                {
                    ongetvalue = ()=> new Gstring( HorizontalOptions.ToString()),
                    onsetvalue = (value) =>{
                        if (value.ToString() == "center")
                            HorizontalOptions = LayoutOptions.Center;
                        else if (value.ToString() == "left")
                            HorizontalOptions = LayoutOptions.Start;
                        else if (value.ToString() == "right")
                            HorizontalOptions = LayoutOptions.End;
                        else if (value.ToString() == "stretch")
                            HorizontalOptions = LayoutOptions.Fill;
                        return 0;
                    }
                } },
                {"Vertical",new FVariable{
                ongetvalue = ()=>new Gstring(VerticalOptions.ToString()),
                onsetvalue = (value)=>
                {
                    if (value.ToString() == "center")
                        VerticalOptions = LayoutOptions.Center;
                    else if (value.ToString() == "bottom")
                        VerticalOptions = LayoutOptions.End;
                    else if (value.ToString() == "stretch")
                        VerticalOptions = LayoutOptions.Fill;
                    else if (value.ToString() == "top")
                        VerticalOptions = LayoutOptions.Start;
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
            switch (IsVisible)
            {
                case true:
                                s = "visiable";
                                break;
                case false:
                                s = "gone";
                                break;
            }
            return new Gstring(s);
                    },
                    onsetvalue = (value)=>
                    {
                        if (value.ToString() == "gone")
                IsVisible = false;
            else if (value.ToString() == "hidden")
                IsVisible = false;
            else if (value.ToString() == "visible")
                IsVisible = true;
                        return 0;
                    }
                } },



                {"Background",new FVariable{
                    ongetvalue = ()=>new Gstring(BackgroundColor.ToString()),
                    onsetvalue = (value)=>
                    {
                        BackgroundColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
                        return 0;
                    }
                } },

                {"Add",new Variable(new MFunction(add,this)) },
                {"AddRow",new Variable(new MFunction(addrow,this)) },
                {"AddColumn",new Variable(new MFunction(addcolume,this)) }



            };

            parent = new GTXAM.Control(this);
            #endregion

        }


        #region 实现IName
        public string Name { get; set; }
        #endregion


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

        public object IGetCSValue()
        {
            return this;
        }

        static GridFlat()
        {
            GType.Sign("gridflat");
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

        GTXAM.Control parent;
        public IOBJ IGetParent()
        {
            return parent;
        }

        #endregion


        //memfunction

        static IFunction add = new Function_Add();
        public class Function_Add : Function
        {
            public Function_Add()
            {
                str_xcname = "con,row,column";
                poslib = "Control";
            }

            public override object Run(Hashtable xc)
            {
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "gridflat");
                var con = xc.GetCSVariableFromSpeType<View>("con", "control");
                var row = Convert.ToInt32(xc.GetCSVariable<object>("row"));
                var column = Convert.ToInt32(xc.GetCSVariable<object>("column"));
                Grid.SetRow(con, row);
                Grid. SetColumn(con, column);
                grid.Children.Add(con);
                return new Variable(0);
            }
        }

        static IFunction addrow = new Function_AddRow();
        public class Function_AddRow : Function
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
                    grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(value, GridUnitType.Absolute) });
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
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(value, GridUnitType.Absolute) });
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


    }

}
