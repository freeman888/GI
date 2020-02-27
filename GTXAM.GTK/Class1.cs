using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace GTXAM.GTK
{
    class Program 
    {
        [STAThread]
        public static void Main(string[] args)
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
<code minversion=""1902"">
  <get value=""Page"" />
  <get value=""IO"" />
  <get value=""Math"" />
  <get value=""Control"" />
  <get value=""System"" />
  <get value=""String"" />
  <get value=""List"" />
  <deffun funname=""Main"" params=""args"" isref=""False"">
    <var_s varname=""page"" str=""var page = Page.Creat(&quot;page1&quot;);"" />
    <getres_s str=""var page = Page.Creat(&quot;page1&quot;);"">
      <arg value=""page"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Page.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""page1"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""bubble"" str=""var bubble = Control.Bubble.Creat(&quot;b&quot;);"" />
    <getres_s str=""var bubble = Control.Bubble.Creat(&quot;b&quot;);"">
      <arg value=""bubble"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Bubble.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""b"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""bubble(&quot;text&quot;,&quot;clickme!&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value=""clickme!"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <var_s varname=""gd"" str=""var gd = Control.GridFlat.Creat(&quot;gf&quot;);"" />
    <getres_s str=""var gd = Control.GridFlat.Creat(&quot;gf&quot;);"">
      <arg value=""gd"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.GridFlat.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""gf"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""bubble(&quot;clickevent&quot;,Click);"">
      <arg con=""fun"">
        <fun>
          <arg value=""bubble"" con=""var"" />
        </fun>
        <params>
          <arg value=""clickevent"" con=""str"" />
          <arg value=""Click"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""gd()(bubble,0,0);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""gd"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""bubble"" con=""var"" />
          <arg value=""0"" con=""num"" />
          <arg value=""0"" con=""num"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""page()(gd);"">
      <arg con=""fun"">
        <fun>
          <arg con=""fun"">
            <fun>
              <arg value=""page"" con=""var"" />
            </fun>
            <params />
          </arg>
        </fun>
        <params>
          <arg value=""gd"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""Page.Load(page);"">
      <arg con=""fun"">
        <fun>
          <arg value=""Page.Load"" con=""var"" />
        </fun>
        <params>
          <arg value=""page"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
  </deffun>
  <deffun funname=""Click"" params=""page,e"" isref=""False"">
    <usefun_s str=""IO.Input();"">
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Input"" con=""var"" />
        </fun>
        <params />
      </arg>
    </usefun_s>
  </deffun>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("WPF_Xamarin");

            Gtk.Application.Init();
            Forms.Init();

            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("Game of Life");
            
            window.Show();

            Gtk.Application.Run();
        }
    }
}
