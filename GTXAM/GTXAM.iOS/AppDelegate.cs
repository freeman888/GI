﻿using Foundation;
using System.Xml;
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
    <get value=""Math"" />
    <get value=""IO"" />
    <get value=""Control"" />
    <get value=""Page"" />
    <get value=""List"" />
    <get value=""String"" />
    <deffun funname=""Main"" params=""args"" isref=""False"">
      <var_s varname=""listflat"" str=""var listflat = ListFlat(&quot;ft&quot;);"" />
      <getres_s str=""var listflat = ListFlat(&quot;ft&quot;);"">
        <arg value=""listflat"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""ListFlat"" con=""var"" />
          </fun>
          <params>
            <arg value=""ft"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <foreach_s var_togive=""i"" var_new=""True"" str=""foreach(var i , Range(1,5)):"">
        <from>
          <arg con=""fun"">
            <fun>
              <arg value=""Range"" con=""var"" />
            </fun>
            <params>
              <arg value=""1"" con=""num"" />
              <arg value=""5"" con=""num"" />
            </params>
          </arg>
        </from>
        <run>
          <usefun_s str=""WriteLine(i);"">
            <arg con=""fun"">
              <fun>
                <arg value=""WriteLine"" con=""var"" />
              </fun>
              <params>
                <arg value=""i"" con=""var"" />
              </params>
            </arg>
          </usefun_s>
          <var_s varname=""textcell"" str=""var textcell = TextCell(&quot;tc&quot;);"" />
          <getres_s str=""var textcell = TextCell(&quot;tc&quot;);"">
            <arg value=""textcell"" con=""var"" />
            <arg con=""fun"">
              <fun>
                <arg value=""TextCell"" con=""var"" />
              </fun>
              <params>
                <arg value=""tc"" con=""str"" />
              </params>
            </arg>
          </getres_s>
          <getres_s str=""textcell:Text = &quot;item&quot; &amp; i;"">
            <arg value=""Text"" con=""mem"">
              <arg value=""textcell"" con=""var"" />
            </arg>
            <arg con=""fun"">
              <fun>
                <arg value=""StringAdd"" con=""var"" />
              </fun>
              <params>
                <arg value=""item"" con=""str"" />
                <arg value=""i"" con=""var"" />
              </params>
            </arg>
          </getres_s>
          <getres_s str=""textcell:Detail = &quot;this is item&quot; &amp; i;"">
            <arg value=""Detail"" con=""mem"">
              <arg value=""textcell"" con=""var"" />
            </arg>
            <arg con=""fun"">
              <fun>
                <arg value=""StringAdd"" con=""var"" />
              </fun>
              <params>
                <arg value=""this is item"" con=""str"" />
                <arg value=""i"" con=""var"" />
              </params>
            </arg>
          </getres_s>
          <getres_s str=""textcell:Clickevent = Click;"">
            <arg value=""Clickevent"" con=""mem"">
              <arg value=""textcell"" con=""var"" />
            </arg>
            <arg value=""Click"" con=""var"" />
          </getres_s>
          <usefun_s str=""listflat:Add(textcell);"">
            <arg con=""fun"">
              <fun>
                <arg value=""Add"" con=""mem"">
                  <arg value=""listflat"" con=""var"" />
                </arg>
              </fun>
              <params>
                <arg value=""textcell"" con=""var"" />
              </params>
            </arg>
          </usefun_s>
        </run>
      </foreach_s>
      <var_s varname=""page"" str=""var page = Page(&quot;title&quot;);"" />
      <getres_s str=""var page = Page(&quot;title&quot;);"">
        <arg value=""page"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""Page"" con=""var"" />
          </fun>
          <params>
            <arg value=""title"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <usefun_s str=""page:SetContent(listflat);"">
        <arg con=""fun"">
          <fun>
            <arg value=""SetContent"" con=""mem"">
              <arg value=""page"" con=""var"" />
            </arg>
          </fun>
          <params>
            <arg value=""listflat"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
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
    <deffun funname=""Click"" params=""object,e"" isref=""False"">
      <usefun_s str=""Message(&quot;you have clicked me&quot;);"">
        <arg con=""fun"">
          <fun>
            <arg value=""Message"" con=""var"" />
          </fun>
          <params>
            <arg value=""you have clicked me"" con=""str"" />
          </params>
        </arg>
      </usefun_s>
    </deffun>
  </lib>
</code>");
            GTXAMInfo.Codes.Add(xmlDocument);
            GTXAMInfo.SetPlatform("IOS_Xamarin");

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
