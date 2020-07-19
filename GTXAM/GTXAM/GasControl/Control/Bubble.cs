
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GI;
using System.Threading.Tasks;

namespace GTXAM.GasControl.Control
{
    public class Bubble : Button, IGetter, ISetter, IOBJ, IName
    {
        public object event_click;
        public Bubble()
        {

            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            Clicked += Bubble_Clicked;

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
                {"Foreground",new FVariable{ ongetvalue =()=>new Gstring(TextColor.ToString()),
                onsetvalue = (value)=>
                {
                    TextColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
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
            parent = new GTXAM.Control(this);
            #endregion
        }

        private async void Bubble_Clicked(object sender, EventArgs e)
        {




            var p = Parent;
            while (!(p is Page.Page))
            {
                p = (p as Element).Parent;
            }
            if (event_click != null && p != null)
            {
                if (event_click is IFunction)
                {
                    IFunction function = event_click as IFunction;
                    Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                    string[] sss = function.Istr_xcname.Split(',');
                    if (sss.Length == 2)
                    {
                        hashtable.Add(sss[0], new Variable(p));
                        hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
                        await Function.NewAsyncFuncStarter(function, new Variable(p),new Variable(e));
                    }
                }
                else
                {
                    IFunction function = Variable.GetTrueVariable<IFunction>(Gasoline.sarray_Sys_Variables, event_click.ToString());
                    Hashtable hashtable = Variable.GetOwnVariables(Gasoline.sarray_Sys_Variables);
                    string[] sss = function.Istr_xcname.Split(',');
                    if (sss.Length == 2)
                    {
                        hashtable.Add(sss[0], new Variable(p));
                        hashtable.Add(sss[1], new Variable(new Glist { new Variable(this), new Variable(e) }));
                        await Function.NewAsyncFuncStarter(function,new Variable(p),new Variable(e));
                    }
                }
            }
        }
        #region 实现IName
        public string Name { get; set; }
        #endregion


        #region 实现IGetter
        object IGetter.IGetWidth()
        {
            return Width;
        }

        object IGetter.IGetHeight()
        {
            return Height;
        }

        object IGetter.IGetHorizontalAlignment()
        {
            return HorizontalOptions.ToString();
        }

        object IGetter.IGetVerticalAlignment()
        {
            return VerticalOptions.ToString();
        }

        object IGetter.IGetMarin()
        {
            string s = string.Format("{0},{0},{0},{0}", Margin.Left, Margin.Top, Margin.Right, Margin.Bottom);
            return s;
        }

        object IGetter.IGetVisibility()
        {
            string s = "null";
            switch (IsVisible)
            {
                case false: s = "gone"; break;
                case true: s = "visible"; break;
            }
            return s;
        }

        object IGetter.IGetText()
        {
            return Text;
        }

        object IGetter.IGetFontSize()
        {
            return FontSize;
        }

        object IGetter.IGetPadding()
        {
            return $"{Padding.Left},{Padding.Top},{Padding.Right},{Padding.Bottom}";
        }

        object IGetter.IGetBackgroundColor()
        {
            return BackgroundColor.ToString();
        }

        object IGetter.IGetForegroundColor()
        {
            return BackgroundColor.ToString();
        }

        object IGetter.IFindID(string id)
        {

            return id == (this as IName).Name ? this : null;
        }

        object IGetter.IGetScrollPosition()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 scrollposition 属性");
        }
        object IGetter.IGetTogged()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }
        #endregion


        #region 实现ISettet


        void ISetter.ISetWidth(object value)
        {
            WidthRequest = Convert.ToDouble(value);
        }

        void ISetter.ISetHeight(object value)
        {
            HeightRequest = Convert.ToDouble(value);
        }
        void ISetter.ISetHorizontalAlignment(object value)
        {
            var view = this;
            if (value.ToString() == "center")
                view.HorizontalOptions = LayoutOptions.Center;
            else if (value.ToString() == "left")
                view.HorizontalOptions = LayoutOptions.Start;
            else if (value.ToString() == "right")
                view.HorizontalOptions = LayoutOptions.End;
            else if (value.ToString() == "stretch")
                view.HorizontalOptions = LayoutOptions.Fill;
        }

        void ISetter.ISetVerticalAlignment(object value)
        {
            var view = this;
            if (value.ToString() == "center")
                view.VerticalOptions = LayoutOptions.Center;
            else if (value.ToString() == "bottom")
                view.VerticalOptions = LayoutOptions.End;
            else if (value.ToString() == "stretch")
                view.VerticalOptions = LayoutOptions.Fill;
            else if (value.ToString() == "top")
                view.VerticalOptions = LayoutOptions.Start;

        }

        void ISetter.ISetMarin(object value)
        {
            double a1, a2, a3, a4;
            string[] vs = value.ToString().Split(',');
            a1 = Convert.ToDouble(vs[0]);
            a2 = Convert.ToDouble(vs[1]);
            a3 = Convert.ToDouble(vs[2]);
            a4 = Convert.ToDouble(vs[3]);
            Margin = new Thickness(a1, a2, a3, a4);
        }

        void ISetter.ISetVisibility(object value)
        {
            var visualElement = this;
            if (value.ToString() == "gone")
                visualElement.IsVisible = false;
            else if (value.ToString() == "hidden")
                visualElement.IsVisible = false;
            else if (value.ToString() == "visible")
                visualElement.IsVisible = true;
        }

        void ISetter.ISetText(object value)
        {
            Text = value.ToString();
        }

        void ISetter.ISetFontSize(object value)
        {
            FontSize = Convert.ToDouble(value);
        }

        void ISetter.ISetPadding(object value)
        {
            double a1, a2, a3, a4;
            string[] vs = value.ToString().Split(',');
            a1 = Convert.ToDouble(vs[0]);
            a2 = Convert.ToDouble(vs[1]);
            a3 = Convert.ToDouble(vs[2]);
            a4 = Convert.ToDouble(vs[3]);
            Padding = new Thickness(a1, a2, a3, a4);
        }

        void ISetter.ISetBackgroundColor(object value)
        {
            BackgroundColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
        }

        void ISetter.ISetForegroundColor(object value)
        {

            TextColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
        }

        void ISetter.ISetTogged(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }

        void ISetter.ISetScrollPosition(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 scrollposition 属性");
        }

        void ISetter.ISetClickEvent(object value)
        {
            event_click = value;
        }


        #endregion


        #region 实现IType
        const string type = "bubble";
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

        static Bubble()
        {
            GType.Sign("bubble");
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



/*
 var arrayList = Variable.GetTrueVariable<Glist>(xc, "params");

    #region 实现IType
        const string type = "bubble,function";
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

        static Bubble()
        {
            GType.Sign("bubble");
        }
#endregion
     */
