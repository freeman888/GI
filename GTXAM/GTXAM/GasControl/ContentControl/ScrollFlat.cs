using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GTXAM.GasControl.Control;
using System.Collections;
using GI;
using System.Threading.Tasks;

namespace GTXAM.GasControl.ContentControl
{/// <summary>
 /// Gasoline 网格布局
 /// </summary>
    public class ScrollFlat : ScrollView, IGetter, ISetter, IOBJ, IName
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
                    ScrollToAsync(();
                    return 0;
                case "end":
                    ScrollToEnd();
                    return 0;
                case "home":
                    ScrollToHome();
                    return 0;
                case "leftend":
                    ScrollToLeftEnd();
                    return 0;
                case "rightend":
                    ScrollToRightEnd();
                    return 0;
                case "top":
                    ScrollToTop();
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
            string s = String.Format("{0},{0},{0},{0}", Margin.Left, Margin.Top, Margin.Right, Margin.Bottom);
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
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 text 属性");
        }

        object IGetter.IGetFontSize()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 fontsize 属性");
        }

        object IGetter.IGetPadding()
        {

            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 padding 属性");
        }

        object IGetter.IGetBackgroundColor()
        {
            return BackgroundColor.ToString();
        }

        object IGetter.IGetForegroundColor()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 foregroundcolor 属性");
        }

        object IGetter.IFindID(string id)
        {

            if (id == Name)
                return this;
            else
            {
                foreach (IGetter i in Children)
                {
                    object o = i.IFindID(id);
                    if (o != null)
                        return o;
                }
                return null;
            }
        }

        object IGetter.IGetScrollPosition()
        {
            return string.Format("{0},{1}", ScrollX, ScrollY);
        }
        object IGetter.IGetTogged()
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }

        #endregion

        #region 实现IName
        public string Name { get; set; }
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
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 text 属性");
        }

        void ISetter.ISetFontSize(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 fontsize 属性");
        }

        void ISetter.ISetPadding(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 padding 属性");
        }

        void ISetter.ISetBackgroundColor(object value)
        {
            BackgroundColor = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());
        }

        void ISetter.ISetForegroundColor(object value)
        {


            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 foreground 属性");
        }


        void ISetter.ISetClickEvent(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "此控件没有 click 事件");
        }


        void ISetter.ISetTogged(object value)
        {
            throw new Exceptions.RunException(Exceptions.EXID.无对应属性, "没有 togged 属性");
        }

        void ISetter.ISetScrollPosition(object value)
        {
            string s_info = value.ToString();
            switch (s_info)
            {
                case "bottom":
                    ScrollToAsync(Content, ScrollToPosition.End, true);

                    return;
                case "end":
                    ScrollToAsync(Content, ScrollToPosition.End, true);
                    return;
                case "home":
                    ScrollToAsync(Content, ScrollToPosition.Start, true);
                    return;
                case "leftend":
                    ScrollToAsync(Content, ScrollToPosition.End, true);
                    return;
                case "rightend":
                    ScrollToAsync(Content, ScrollToPosition.End, true);
                    return;
                case "top":
                    ScrollToAsync(Content, ScrollToPosition.Start, true);
                    return;
                default:
                    break;
            }
            var list = value.ToString().Split(',');
            ScrollToAsync(double.Parse(list[0]), double.Parse(list[1]), true);
        }
        #endregion
        #region 实现IType
        const string type = "scrollflat,function";
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
                var grid = xc.GetCSVariableFromSpeType<GridFlat>("this", "gridflat");
                var content = xc.GetCSVariableFromSpeType<View>("control", "control");

                grid.Children.Add(content);
                return new Variable(0);
            }
        }
    }

}
