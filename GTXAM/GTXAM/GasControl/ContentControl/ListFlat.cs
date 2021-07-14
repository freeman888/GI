using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GI;
using static GI.Function;
using System.Collections;

namespace GTXAM.GasControl.ContentControl
{
    public class ListFlat : TableView, IOBJ,IName
    {
        internal TableSection cells = new TableSection();
        public ListFlat()
        {
            this.Root = new TableRoot();
            cells.Title = "List";
            Root.Title = "title";
            Root.Add(cells);
            
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
                {"Background",new FVariable{
                    ongetvalue = ()=>new Gstring(BackgroundColor.ToString()),
                    onsetvalue = (value)=>
                    {
                        BackgroundColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
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




                {"Add",new Variable(new MFunction(add,this)) },
                {"Clear",new Variable(new MFunction(clear,this)) }




            };
            
            parent = new GTXAM.Control(this);
        }

        #region 实现IOBJ

        public object IGetCSValue()
        {
            return this;
        }
        const string type = "listflat";
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
            GType.Sign("listflat");
        }
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

        #region 实现IName
        public string Name { get; set; }
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
                var listflat = xc.GetCSVariableFromSpeType<ListFlat>("this", "listflat");
                var con = xc.GetCSVariableFromSpeType<Xamarin.Forms.Cell>("con", "cell");

                listflat.cells.Add(con);
                

                return new Variable(0);
            }
        }
        static IFunction clear = new Function_ListFlat_Clear();
        public class Function_ListFlat_Clear:Function
        {
            public Function_ListFlat_Clear()
            {
                IInformation = "";
                str_xcname = "";
            }
            public override object Run(Hashtable xc)
            {
                var listflat = xc.GetCSVariableFromSpeType<ListFlat>("this", "listflat");
                listflat.cells.Clear();
                return new Variable(0);
            }
        }

    }
}
