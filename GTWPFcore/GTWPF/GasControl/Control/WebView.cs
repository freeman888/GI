using GI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using static GI.Function;

namespace GTWPF.GasControl.Control
{
    public class WebView : IOBJ
    {
        public System.Windows.Controls.WebBrowser webBrowser = new System.Windows.Controls.WebBrowser();


        public WebView()
        {
            webBrowser.HorizontalAlignment = HorizontalAlignment.Stretch;
            webBrowser.VerticalAlignment = VerticalAlignment.Stretch;

            #region
            members = new Dictionary<string, Variable>
            {
                {"Width" ,new FVariable{
                    ongetvalue = ()=>new Gnumber(webBrowser.Width),
                    onsetvalue = (value)=>{webBrowser.Width =Convert.ToDouble( value); return 0; }}},
                {"Height" ,new FVariable
                {
                    ongetvalue = ()=>new Gnumber(webBrowser.Height),
                    onsetvalue = (value)=>{webBrowser.Height = Convert.ToDouble(value);return 0; }
                }},
                {"Horizontal",new FVariable

                {
                    ongetvalue = ()=> new Gstring( webBrowser.HorizontalAlignment.ToString()),
                    onsetvalue = (value) =>{
                        if (value.ToString() == "center")
                            webBrowser.HorizontalAlignment = HorizontalAlignment.Center;
                        else if (value.ToString() == "left")
                            webBrowser.HorizontalAlignment = HorizontalAlignment.Left;
                        else if (value.ToString() == "right")
                            webBrowser.HorizontalAlignment = HorizontalAlignment.Right;
                        else if (value.ToString() == "stretch")
                            webBrowser.HorizontalAlignment = HorizontalAlignment.Stretch;
                        return 0;
                    }
                } },
                {"Vertical",new FVariable{
                ongetvalue = ()=>new Gstring(webBrowser.VerticalAlignment.ToString()),
                onsetvalue = (value)=>
                {
                    if (value.ToString() == "center")
                        webBrowser.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        webBrowser.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        webBrowser.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        webBrowser.VerticalAlignment = VerticalAlignment.Top;
                    return 0;
                }
                } },
                {"Margin",new FVariable{
                ongetvalue =() => new Glist{new Variable(webBrowser.Margin.Left) ,new Variable(webBrowser.Margin.Top),new Variable(webBrowser.Margin.Right),new Variable(webBrowser.Margin.Bottom)},
                onsetvalue = (value)=>
                {
                    var list = value.IGetCSValue() as Glist;
                    webBrowser.Margin = new Thickness(
                        Convert.ToDouble( list[0].value),Convert.ToDouble(list[1].value),Convert.ToDouble(list[2].value),Convert.ToDouble(list[3].value)
                          );
                    return 0;
                }

                } },
                {"Visibility",new FVariable{
                    ongetvalue = () =>
                    {
                        string s = "null";
            switch (webBrowser. Visibility)
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
                webBrowser. Visibility = Visibility.Collapsed;
            else if (value.ToString() == "hidden")
                webBrowser.Visibility = Visibility.Hidden;
            else if (value.ToString() == "visible")
                webBrowser.Visibility = Visibility.Visible;
                        return 0;
                    }
                } },
                { "Url" , new FVariable{
                ongetvalue = ()=> new Gstring(webBrowser.Source.ToString()),
                onsetvalue = (value)=>
                {
                    webBrowser.Source = new Uri( value.ToString());
                    return 0;
                } } },
                {
                    "InvokeJS",new Variable(new MFunction(invokejs,this))
                }

            };
            parent = new GTWPF.Control(webBrowser);
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

            public override object Run(Dictionary<string,Variable> xc)
            {
                var list = xc.GetCSVariable<Glist>("params");
                string jsfun = list[0].value.IGetCSValue().ToString();
                list.RemoveAt(0);
                List<object> objs = new List<object>();
                foreach (var i in list)
                {
                    objs.Add(i.value.IGetCSValue());
                }


                //string jsfun = xc.GetCSVariable<object>("jsfun").ToString();
                var webview = xc.GetCSVariableFromSpeType<System.Windows.Controls.WebBrowser>("this", "WebView");
                var res = webview.InvokeScript(jsfun, objs.ToArray());
                return new Variable(res);
            }
        }


        #region 实现Itype
        const string type = "WebView";
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
            return webBrowser;
        }
        static WebView()
        {
            GType.Sign("WebView");
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

        public static IOBJ GetWebViewFromXml(XmlElement xmlelement)

        {
            var webview = new WebView();
            webview.webBrowser.Name = xmlelement.GetAttribute("Name");
            //Width
            {
                var value = xmlelement.GetAttribute("Width");
                if (!string.IsNullOrEmpty(value))
                    webview.webBrowser.Width = Convert.ToDouble(value);
            }
            //Height
            {
                var value = xmlelement.GetAttribute("Height");
                if (!string.IsNullOrEmpty(value))
                    webview.webBrowser.Height = Convert.ToDouble(value);
            }
            //Horizontal
            {
                var value = xmlelement.GetAttribute("Horizontal");
                if (!string.IsNullOrEmpty(value))
                {

                    if (value.ToString() == "center")
                        webview.webBrowser.HorizontalAlignment = HorizontalAlignment.Center;
                    else if (value.ToString() == "left")
                        webview.webBrowser.HorizontalAlignment = HorizontalAlignment.Left;
                    else if (value.ToString() == "right")
                        webview.webBrowser.HorizontalAlignment = HorizontalAlignment.Right;
                    else if (value.ToString() == "stretch")
                        webview.webBrowser.HorizontalAlignment = HorizontalAlignment.Stretch;
                }

            }
            //Vertical

            {

                var value = xmlelement.GetAttribute("Vertical");

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.ToString() == "center")
                        webview.webBrowser.VerticalAlignment = VerticalAlignment.Center;
                    else if (value.ToString() == "bottom")
                        webview.webBrowser.VerticalAlignment = VerticalAlignment.Bottom;
                    else if (value.ToString() == "stretch")
                        webview.webBrowser.VerticalAlignment = VerticalAlignment.Stretch;
                    else if (value.ToString() == "top")
                        webview.webBrowser.VerticalAlignment = VerticalAlignment.Top;
                }
            }
            //Margin
            {
                var value = xmlelement.GetAttribute("Margin");
                if (!string.IsNullOrEmpty(value))
                {
                    var list = value.Split(',');
                    webview.webBrowser.Margin = new Thickness(
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
                        webview.webBrowser.Visibility = Visibility.Collapsed;
                    else if (value.ToString() == "hidden")
                        webview.webBrowser.Visibility = Visibility.Hidden;
                    else if (value.ToString() == "visible")
                        webview.webBrowser.Visibility = Visibility.Visible;
                }
            }
            //Row
            {
                var value = xmlelement.GetAttribute("Row");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetRow(webview.webBrowser, Convert.ToInt32(value));

            }
            //Column
            {
                var value = xmlelement.GetAttribute("Column");
                if (!string.IsNullOrEmpty(value))
                    Grid.SetColumn(webview.webBrowser, Convert.ToInt32(value));
            }
            //Url
            {
                var value = xmlelement.GetAttribute("Url");
                if (!string.IsNullOrEmpty(value))
                    webview.webBrowser.Source = new Uri(value.ToString());
            }
            return webview;
        }
    }
}
