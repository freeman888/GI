using System;
using System.Xml;
using Gtk;
using GTXAM;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace GTMAC.GTK
{
    class MainClass
    {
      
            [STAThread]
            public static void Main(string[] args)
            {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(@"<code minversion=""2007"">
  <lib name=""App1"">
    <get value=""IO"" />
    <get value=""Math"" />
    <get value=""Page"" />
    <deffun funname=""Main"" params=""args"" isref=""False"">
      <var_s varname=""page"" str=""var page = Page(&quot;mainpage&quot;);"" />
      <getres_s str=""var page = Page(&quot;mainpage&quot;);"">
        <arg value=""page"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""Page"" con=""var"" />
          </fun>
          <params>
            <arg value=""mainpage"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <usefun_s str=""PageLoad(page);"">
        <arg con=""fun"">
          <fun>
            <arg value=""PageLoad"" con=""var"" />
          </fun>
          <params>
            <arg value=""page"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
    </deffun>
  </lib>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("WPF_Xamarin");



            Gtk.Application.Init();
                Forms.Init();

                var app = new GTXAM.App();
                var window = new FormsWindow();
                window.LoadApplication(app);
                window.SetApplicationTitle("Gasoline");
                window.Show();

                Gtk.Application.Run();
            }
        
    }
}
