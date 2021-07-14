using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GI;
using System.Threading.Tasks;
using System.Diagnostics;
using static GI.Function;

namespace GTXAM.GasControl.Control
{
     public class WebView:Xamarin.Forms.WebView,IOBJ,IName
    {


        public WebView()
        {
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Fill;
            
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
                { "Url" , new FVariable{
                ongetvalue = ()=> new Gstring(this.Source.ToString()),
                onsetvalue = (value)=>
                {
                    var path = value.ToString();
                    if(GIInfo.Platform == "Mac_Xamarin")
                    {

                        path = path.Replace("\\","/");
                    }
                    Source = new UrlWebViewSource{ Url = path };
                    return 0;
                } } },
                {
                    "InvokeJS",new Variable(new MFunction(invokejs,this))
                }
            };
            parent = new GTXAM.Control(this);
            #endregion
        }
        static IFunction invokejs = new WebView_Function_InvokeJS();
        public class WebView_Function_InvokeJS : Function
        {
            public WebView_Function_InvokeJS()
            {
                IInformation = "invoke js function in gasoline";
                str_xcname = "params";
            }

            public  override object Run(Hashtable xc)
            {
                var list = xc.GetCSVariable<Glist>("params");
                string jsfun = list[0].value.IGetCSValue().ToString();
                list.RemoveAt(0);
                List<string> objs = new List<string>();
                foreach (var i in list)
                {
                    objs.Add("'"+i.value.IGetCSValue().ToString()+"'");
                }


                var webview = xc.GetCSVariableFromSpeType<WebView>("this", "webview");
                var res =  webview.funinvokejs?.Invoke($"{jsfun} ({string.Join(",", objs)})");
                return new Variable(res);
            }
        }
        public Func<string, string> funinvokejs = null;


        #region 实现IName
        public string Name { get; set; }
        #endregion


        #region 实现IType
        const string type = "webview";
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

        static WebView()
        {
            GType.Sign("webview");
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
