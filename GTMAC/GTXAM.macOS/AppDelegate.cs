using System.Xml;
using AppKit;
using Foundation;
using GTXAM;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace GTMAC
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow window;
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 800, 600);
            window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            window.Title = "Gasoline on Mac!"; // choose your own Title here
            window.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        public override NSWindow MainWindow
        {
            get { return window; }
        }

        public override void DidFinishLaunching(NSNotification notification)
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

            Forms.Init();
            LoadApplication(new GTXAM.App());
            base.DidFinishLaunching(notification);
        }
    }
}
