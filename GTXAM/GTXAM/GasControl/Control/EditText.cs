using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GI;
using System.Threading.Tasks;

namespace GTXAM.GasControl.Control
{

    /// <summary>
    /// Gasoline 编辑框
    /// </summary>
    public class EditText : Editor, IOBJ, IName
    {
        public EditText()
        {
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            
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
                    ongetvalue = ()=>new Gstring(BackgroundColor.ToString()),
                    onsetvalue = (value)=>
                    {
                        BackgroundColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
                        return 0;
                    }
                } },
                {"Foreground",new FVariable{ ongetvalue =()=>new Gstring(TextColor.ToString()),
                onsetvalue = (value)=>
                {
                    TextColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
                    return 0;
                } } },




            };
            parent = new GTXAM.Control(this);
            #endregion
        }
        #region 实现IName
        public string Name { get; set; }
        #endregion




        #region 实现IType
        const string type = "edittext";
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

        static EditText()
        {
            GType.Sign("edittext");
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

    }
}
