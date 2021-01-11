using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Foundation;
using UIKit;

namespace GTXAM.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
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
            GTXAMInfo.SetPlatform("IOS_Xamarin");

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
