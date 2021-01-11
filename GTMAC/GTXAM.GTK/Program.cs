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
            xmlDocument.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
<code minversion=""2007"">
  <lib name=""Program"">
    <get value=""IO"" />
    <get value=""Control"" />
    <get value=""Page"" />
    <deffun funname=""Main"" params=""args"" isref=""False"">
      <var_s varname=""page"" str=""var page = MainPage(&quot;MainPage&quot;);"" />
      <getres_s str=""var page = MainPage(&quot;MainPage&quot;);"">
        <arg value=""page"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""MainPage"" con=""var"" />
          </fun>
          <params>
            <arg value=""MainPage"" con=""str"" />
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
    <cls name=""MainPage"" parent=""Page"">
      <member value=""bubble"" />
      <member value=""tip"" />
      <memfun funname=""init"" params=""title"" isref=""False"" isstatic=""False"">
        <getres_s str=""this:bubble = Bubble(&quot;bu&quot;);"">
          <arg value=""bubble"" con=""mem"">
            <arg value=""this"" con=""var"" />
          </arg>
          <arg con=""fun"">
            <fun>
              <arg value=""Bubble"" con=""var"" />
            </fun>
            <params>
              <arg value=""bu"" con=""str"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""this:bubble:Text = &quot;Click me!&quot;;"">
          <arg value=""Text"" con=""mem"">
            <arg value=""bubble"" con=""mem"">
              <arg value=""this"" con=""var"" />
            </arg>
          </arg>
          <arg value=""Click me!"" con=""str"" />
        </getres_s>
        <getres_s str=""this:bubble:Clickevent = this:BuClick;"">
          <arg value=""Clickevent"" con=""mem"">
            <arg value=""bubble"" con=""mem"">
              <arg value=""this"" con=""var"" />
            </arg>
          </arg>
          <arg value=""BuClick"" con=""mem"">
            <arg value=""this"" con=""var"" />
          </arg>
        </getres_s>
        <usefun_s str=""this:SetContent(this:bubble);"">
          <arg con=""fun"">
            <fun>
              <arg value=""SetContent"" con=""mem"">
                <arg value=""this"" con=""var"" />
              </arg>
            </fun>
            <params>
              <arg value=""bubble"" con=""mem"">
                <arg value=""this"" con=""var"" />
              </arg>
            </params>
          </arg>
        </usefun_s>
      </memfun>
      <memfun funname=""BuClick"" params=""page,e"" isref=""False"" isstatic=""False"">
        <usefun_s str=""Message(&quot;HHH&quot;);"">
          <arg con=""fun"">
            <fun>
              <arg value=""Message"" con=""var"" />
            </fun>
            <params>
              <arg value=""HHH"" con=""str"" />
            </params>
          </arg>
        </usefun_s>
      </memfun>
    </cls>
  </lib>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("GTK_Xamarin");



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
