using System.Diagnostics;
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
            window.WillClose += Window_WillClose;
            window.Title = "Gasoline on Mac!"; // choose your own Title here
            window.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        private void Window_WillClose(object sender, System.EventArgs e)
        {
            System.Environment.Exit(0);
        }

        public override NSWindow MainWindow
        {
            get { return window; }
        }

        public override void DidFinishLaunching(NSNotification notification)
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(@"<code minversion=""2007"">
  <lib name=""FreeStudio"">
    <get value=""IO"" />
    <get value=""Control"" />
    <get value=""Page"" />
    <get value=""List"" />
    <get value=""File"" />
    <get value=""String"" />
    <deffun funname=""Main"" params=""args"" isref=""False"">
      <usefun_s str=""WriteLine(&quot;hello,world&quot;);"">
        <arg con=""fun"">
          <fun>
            <arg value=""WriteLine"" con=""var"" />
          </fun>
          <params>
            <arg value=""hello,world"" con=""str"" />
          </params>
        </arg>
      </usefun_s>
      <var_s varname=""mp"" str=""var mp = MainPage(&quot;FreeStudio&quot;);"" />
      <getres_s str=""var mp = MainPage(&quot;FreeStudio&quot;);"">
        <arg value=""mp"" con=""var"" />
        <arg con=""fun"">
          <fun>
            <arg value=""MainPage"" con=""var"" />
          </fun>
          <params>
            <arg value=""FreeStudio"" con=""str"" />
          </params>
        </arg>
      </getres_s>
      <usefun_s str=""PageLoad(mp);"">
        <arg con=""fun"">
          <fun>
            <arg value=""PageLoad"" con=""var"" />
          </fun>
          <params>
            <arg value=""mp"" con=""var"" />
          </params>
        </arg>
      </usefun_s>
    </deffun>
    <cls name=""MainPage"" parent=""Page"">
      <member value=""gf1"" />
      <memfun funname=""init"" params=""title"" isref=""False"" isstatic=""False"">
        <var_s varname=""tip_title"" str=""var tip_title = Tip(&quot;title&quot;);"" />
        <getres_s str=""var tip_title = Tip(&quot;title&quot;);"">
          <arg value=""tip_title"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Tip"" con=""var"" />
            </fun>
            <params>
              <arg value=""title"" con=""str"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""tip_title:Text = &quot;FreeStudio&quot;;"">
          <arg value=""Text"" con=""mem"">
            <arg value=""tip_title"" con=""var"" />
          </arg>
          <arg value=""FreeStudio"" con=""str"" />
        </getres_s>
        <getres_s str=""tip_title:FontSize = 60;"">
          <arg value=""FontSize"" con=""mem"">
            <arg value=""tip_title"" con=""var"" />
          </arg>
          <arg value=""60"" con=""num"" />
        </getres_s>
        <getres_s str=""tip_title:Horizontal = &quot;center&quot;;"">
          <arg value=""Horizontal"" con=""mem"">
            <arg value=""tip_title"" con=""var"" />
          </arg>
          <arg value=""center"" con=""str"" />
        </getres_s>
        <getres_s str=""tip_title:Vertical = &quot;center&quot;;"">
          <arg value=""Vertical"" con=""mem"">
            <arg value=""tip_title"" con=""var"" />
          </arg>
          <arg value=""center"" con=""str"" />
        </getres_s>
        <getres_s str=""tip_title:Margin = List(0,0,0,450);"">
          <arg value=""Margin"" con=""mem"">
            <arg value=""tip_title"" con=""var"" />
          </arg>
          <arg con=""fun"">
            <fun>
              <arg value=""List"" con=""var"" />
            </fun>
            <params>
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
              <arg value=""450"" con=""num"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""tip_title:Foreground = &quot;white&quot;;"">
          <arg value=""Foreground"" con=""mem"">
            <arg value=""tip_title"" con=""var"" />
          </arg>
          <arg value=""white"" con=""str"" />
        </getres_s>
        <var_s varname=""bu_1"" str=""var bu_1 = Bubble(&quot;bu_1&quot;);"" />
        <getres_s str=""var bu_1 = Bubble(&quot;bu_1&quot;);"">
          <arg value=""bu_1"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Bubble"" con=""var"" />
            </fun>
            <params>
              <arg value=""bu_1"" con=""str"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""bu_1:Text = &quot;创建一个项目&quot;;"">
          <arg value=""Text"" con=""mem"">
            <arg value=""bu_1"" con=""var"" />
          </arg>
          <arg value=""创建一个项目"" con=""str"" />
        </getres_s>
        <getres_s str=""bu_1:FontSize = 30;"">
          <arg value=""FontSize"" con=""mem"">
            <arg value=""bu_1"" con=""var"" />
          </arg>
          <arg value=""30"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_1:Height = 60;"">
          <arg value=""Height"" con=""mem"">
            <arg value=""bu_1"" con=""var"" />
          </arg>
          <arg value=""60"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_1:Width = 220;"">
          <arg value=""Width"" con=""mem"">
            <arg value=""bu_1"" con=""var"" />
          </arg>
          <arg value=""220"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_1:Margin = List(0,0,0,230);"">
          <arg value=""Margin"" con=""mem"">
            <arg value=""bu_1"" con=""var"" />
          </arg>
          <arg con=""fun"">
            <fun>
              <arg value=""List"" con=""var"" />
            </fun>
            <params>
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
              <arg value=""230"" con=""num"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""bu_1:Foreground = &quot;white&quot;;"">
          <arg value=""Foreground"" con=""mem"">
            <arg value=""bu_1"" con=""var"" />
          </arg>
          <arg value=""white"" con=""str"" />
        </getres_s>
        <var_s varname=""bu_2"" str=""var bu_2 = Bubble(&quot;bu_2&quot;);"" />
        <getres_s str=""var bu_2 = Bubble(&quot;bu_2&quot;);"">
          <arg value=""bu_2"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Bubble"" con=""var"" />
            </fun>
            <params>
              <arg value=""bu_2"" con=""str"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""bu_2:Text = &quot;打开一个项目&quot;;"">
          <arg value=""Text"" con=""mem"">
            <arg value=""bu_2"" con=""var"" />
          </arg>
          <arg value=""打开一个项目"" con=""str"" />
        </getres_s>
        <getres_s str=""bu_2:FontSize = 30;"">
          <arg value=""FontSize"" con=""mem"">
            <arg value=""bu_2"" con=""var"" />
          </arg>
          <arg value=""30"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_2:Height = 60;"">
          <arg value=""Height"" con=""mem"">
            <arg value=""bu_2"" con=""var"" />
          </arg>
          <arg value=""60"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_2:Width = 220;"">
          <arg value=""Width"" con=""mem"">
            <arg value=""bu_2"" con=""var"" />
          </arg>
          <arg value=""220"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_2:Margin = List(0,0,0,110);"">
          <arg value=""Margin"" con=""mem"">
            <arg value=""bu_2"" con=""var"" />
          </arg>
          <arg con=""fun"">
            <fun>
              <arg value=""List"" con=""var"" />
            </fun>
            <params>
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
              <arg value=""110"" con=""num"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""bu_2:Foreground = &quot;white&quot;;"">
          <arg value=""Foreground"" con=""mem"">
            <arg value=""bu_2"" con=""var"" />
          </arg>
          <arg value=""white"" con=""str"" />
        </getres_s>
        <var_s varname=""bu_3"" str=""var bu_3 = Bubble(&quot;bu_3&quot;);"" />
        <getres_s str=""var bu_3 = Bubble(&quot;bu_3&quot;);"">
          <arg value=""bu_3"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Bubble"" con=""var"" />
            </fun>
            <params>
              <arg value=""bu_3"" con=""str"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""bu_3:Text = &quot;帮助&quot;;"">
          <arg value=""Text"" con=""mem"">
            <arg value=""bu_3"" con=""var"" />
          </arg>
          <arg value=""帮助"" con=""str"" />
        </getres_s>
        <getres_s str=""bu_3:FontSize = 30;"">
          <arg value=""FontSize"" con=""mem"">
            <arg value=""bu_3"" con=""var"" />
          </arg>
          <arg value=""30"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_3:Height = 60;"">
          <arg value=""Height"" con=""mem"">
            <arg value=""bu_3"" con=""var"" />
          </arg>
          <arg value=""60"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_3:Width = 220;"">
          <arg value=""Width"" con=""mem"">
            <arg value=""bu_3"" con=""var"" />
          </arg>
          <arg value=""220"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_3:Margin = List(0,10,0,0);"">
          <arg value=""Margin"" con=""mem"">
            <arg value=""bu_3"" con=""var"" />
          </arg>
          <arg con=""fun"">
            <fun>
              <arg value=""List"" con=""var"" />
            </fun>
            <params>
              <arg value=""0"" con=""num"" />
              <arg value=""10"" con=""num"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""bu_3:Foreground = &quot;white&quot;;"">
          <arg value=""Foreground"" con=""mem"">
            <arg value=""bu_3"" con=""var"" />
          </arg>
          <arg value=""white"" con=""str"" />
        </getres_s>
        <var_s varname=""bu_4"" str=""var bu_4 = Bubble(&quot;bu_4&quot;);"" />
        <getres_s str=""var bu_4 = Bubble(&quot;bu_4&quot;);"">
          <arg value=""bu_4"" con=""var"" />
          <arg con=""fun"">
            <fun>
              <arg value=""Bubble"" con=""var"" />
            </fun>
            <params>
              <arg value=""bu_4"" con=""str"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""bu_4:Text = &quot;设置&quot;;"">
          <arg value=""Text"" con=""mem"">
            <arg value=""bu_4"" con=""var"" />
          </arg>
          <arg value=""设置"" con=""str"" />
        </getres_s>
        <getres_s str=""bu_4:FontSize = 30;"">
          <arg value=""FontSize"" con=""mem"">
            <arg value=""bu_4"" con=""var"" />
          </arg>
          <arg value=""30"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_4:Height = 60;"">
          <arg value=""Height"" con=""mem"">
            <arg value=""bu_4"" con=""var"" />
          </arg>
          <arg value=""60"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_4:Width = 220;"">
          <arg value=""Width"" con=""mem"">
            <arg value=""bu_4"" con=""var"" />
          </arg>
          <arg value=""220"" con=""num"" />
        </getres_s>
        <getres_s str=""bu_4:Margin = List(0,130,0,0);"">
          <arg value=""Margin"" con=""mem"">
            <arg value=""bu_4"" con=""var"" />
          </arg>
          <arg con=""fun"">
            <fun>
              <arg value=""List"" con=""var"" />
            </fun>
            <params>
              <arg value=""0"" con=""num"" />
              <arg value=""130"" con=""num"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""bu_4:Foreground = &quot;white&quot;;"">
          <arg value=""Foreground"" con=""mem"">
            <arg value=""bu_4"" con=""var"" />
          </arg>
          <arg value=""white"" con=""str"" />
        </getres_s>
        <getres_s str=""this:gf1 = GridFlat(&quot;gf1&quot;);"">
          <arg value=""gf1"" con=""mem"">
            <arg value=""this"" con=""var"" />
          </arg>
          <arg con=""fun"">
            <fun>
              <arg value=""GridFlat"" con=""var"" />
            </fun>
            <params>
              <arg value=""gf1"" con=""str"" />
            </params>
          </arg>
        </getres_s>
        <getres_s str=""this:gf1:Background = &quot;#323232&quot;;"">
          <arg value=""Background"" con=""mem"">
            <arg value=""gf1"" con=""mem"">
              <arg value=""this"" con=""var"" />
            </arg>
          </arg>
          <arg value=""#323232"" con=""str"" />
        </getres_s>
        <usefun_s str=""this:gf1:Add(tip_title,0,0);"">
          <arg con=""fun"">
            <fun>
              <arg value=""Add"" con=""mem"">
                <arg value=""gf1"" con=""mem"">
                  <arg value=""this"" con=""var"" />
                </arg>
              </arg>
            </fun>
            <params>
              <arg value=""tip_title"" con=""var"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
            </params>
          </arg>
        </usefun_s>
        <usefun_s str=""this:gf1:Add(bu_1,0,0);"">
          <arg con=""fun"">
            <fun>
              <arg value=""Add"" con=""mem"">
                <arg value=""gf1"" con=""mem"">
                  <arg value=""this"" con=""var"" />
                </arg>
              </arg>
            </fun>
            <params>
              <arg value=""bu_1"" con=""var"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
            </params>
          </arg>
        </usefun_s>
        <usefun_s str=""this:gf1:Add(bu_2,0,0);"">
          <arg con=""fun"">
            <fun>
              <arg value=""Add"" con=""mem"">
                <arg value=""gf1"" con=""mem"">
                  <arg value=""this"" con=""var"" />
                </arg>
              </arg>
            </fun>
            <params>
              <arg value=""bu_2"" con=""var"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
            </params>
          </arg>
        </usefun_s>
        <usefun_s str=""this:gf1:Add(bu_3,0,0);"">
          <arg con=""fun"">
            <fun>
              <arg value=""Add"" con=""mem"">
                <arg value=""gf1"" con=""mem"">
                  <arg value=""this"" con=""var"" />
                </arg>
              </arg>
            </fun>
            <params>
              <arg value=""bu_3"" con=""var"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
            </params>
          </arg>
        </usefun_s>
        <usefun_s str=""this:gf1:Add(bu_4,0,0);"">
          <arg con=""fun"">
            <fun>
              <arg value=""Add"" con=""mem"">
                <arg value=""gf1"" con=""mem"">
                  <arg value=""this"" con=""var"" />
                </arg>
              </arg>
            </fun>
            <params>
              <arg value=""bu_4"" con=""var"" />
              <arg value=""0"" con=""num"" />
              <arg value=""0"" con=""num"" />
            </params>
          </arg>
        </usefun_s>
        <usefun_s str=""this:SetContent(this:gf1);"">
          <arg con=""fun"">
            <fun>
              <arg value=""SetContent"" con=""mem"">
                <arg value=""this"" con=""var"" />
              </arg>
            </fun>
            <params>
              <arg value=""gf1"" con=""mem"">
                <arg value=""this"" con=""var"" />
              </arg>
            </params>
          </arg>
        </usefun_s>
      </memfun>
    </cls>
  </lib>
</code>");
            GTXAMInfo.Codes.Add(  xmlDocument);
            GTXAMInfo.SetPlatform("Mac_Xamarin");

            Forms.Init();
            LoadApplication(new GTXAM.App());
            base.DidFinishLaunching(notification);
        }
    }
}
