﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using GI;
using System.Windows.Media;
using System.Collections;

namespace GTWPF.GasControl.ContentControl
{
    public class StackFlat:StackPanel,IOBJ
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
                {
                    "Orientation",new FVariable
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
        static IFunction add = new StackFlat_Function_Add();
        public class StackFlat_Function_Add:Function
        {
            public StackFlat_Function_Add()
            {
                
                IInformation = "add a control to this stackflat";
                str_xcname = "control";
            }
            public override object Run(Hashtable xc)
            {
                var stackflat = xc.GetCSVariableFromSpeType<StackFlat>("this", "stackflat");
                var control = xc.GetCSVariableFromSpeType<UIElement>("control", "control");
                stackflat.Children.Add(control);
                return new Variable(0);
            }
        }

        #region 实现IType
        const string type = "stackflat";
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
            GType.Sign("stackflat");
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
