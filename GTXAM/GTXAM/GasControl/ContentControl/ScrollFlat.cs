using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GTXAM.GasControl.Control;
using System.Collections;
using GI;
using System.Threading.Tasks;
using static GI.Function;

namespace GTXAM.GasControl.ContentControl
{/// <summary>
 /// Gasoline 网格布局
 /// </summary>
    public class ScrollFlat : ScrollView, IOBJ, IName
    {

        public ScrollFlat()
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
                
                
                {"Padding" ,new FVariable{
                    ongetvalue =() => new Glist{new Variable(Padding.Left) ,new Variable(Padding.Top),new Variable(Padding.Right),new Variable(Padding.Bottom)},
                onsetvalue = (value)=>
                {
                    var list = value.IGetCSValue() as Glist;
                    Padding = new Thickness(
                        Convert.ToDouble( list[0].value),Convert.ToDouble(list[1].value),Convert.ToDouble(list[2].value),Convert.ToDouble(list[3].value)
                          );
                    return 0;
                }} },
                {"Background",new FVariable{
                    ongetvalue = ()=>new Gstring(BackgroundColor.ToString()),
                    onsetvalue = (value)=>
                    {
                        BackgroundColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
                        return 0;
                    }
                } },

                {"ScrollPosition" ,new FVariable
                {
                    ongetvalue = ()=>
                    {
                        return new Glist
                        {
                            new Variable(ScrollX),
                            new Variable(ScrollY)
                        };
                    },
                    onsetvalue = (value)=>
                    {
                        if(value.IGetType() == "list")
                        {
                            var list = value.IGetCSValue() as Glist;
                            var ho =Convert.ToDouble( list[0].value);
                            var vo = Convert.ToDouble(list[1].value);
                            ScrollToAsync(ho,vo,true);
                        }
                        else
                        {
                            string s_info = value.ToString();
            switch (s_info) 
            {
                case "bottom":
                    ScrollToAsync(Content,ScrollToPosition.End,true);
                    return 0;
                case "end":
                    ScrollToAsync(Content,ScrollToPosition.End,true);
                    return 0;
                case "home":
                    ScrollToAsync(Content,ScrollToPosition.Start,true);
                    return 0;
                case "leftend":
                    ScrollToAsync(Content,ScrollToPosition.End,true);
                    return 0;
                case "rightend":
                    ScrollToAsync(Content,ScrollToPosition.End,true);
                    return 0;
                case "top":
                                    ScrollToAsync(Content,ScrollToPosition.Start,true);
                    return 0;
                default:
                    break;
            }
                        }
                        return 0;
                    }
                } },
                {"SetContent",new Variable(new MFunction(setcontent,this)) }




            };
            parent = new GTXAM.Control(this);
            #endregion
        }


        #region 实现IName
        public string Name { get; set; }
        #endregion




        #region 实现IType
        const string type = "scrollflat";
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

        static ScrollFlat()
        {
            GType.Sign("scrollflat");
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
        //memfunction
        static IFunction setcontent = new Function_SetContent();
        public class Function_SetContent : Function
        {
            public Function_SetContent()
            {
                str_xcname = "control";
                IInformation = "";
            }

            public override object Run(Hashtable xc)
            {
                var sf = xc.GetCSVariableFromSpeType<ScrollFlat>("this", "scrollflat");
                var content = xc.GetCSVariableFromSpeType<View>("control", "control");

                sf.Content = content;
                return new Variable(0);
            }
        }
    }

}
