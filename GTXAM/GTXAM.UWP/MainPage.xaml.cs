using System.Xml;

namespace GTXAM.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
<code minversion=""1902"">
  <get value=""IO"" />
  <get value=""Math"" />
  <get value=""Control"" />
  <get value=""Page"" />
  <deffun funname=""Main"" params=""a"" isref=""False"">
    <var_s varname=""page"" str=""var page = Page.Creat(&quot;page&quot;);"" />
    <getres_s str=""var page = Page.Creat(&quot;page&quot;);"">
      <arg value=""page"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Page.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""page"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <var_s varname=""bu"" str=""var bu = Control.Bubble.Creat(&quot;b1&quot;);"" />
    <getres_s str=""var bu = Control.Bubble.Creat(&quot;b1&quot;);"">
      <arg value=""bu"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""Control.Bubble.Creat"" con=""var"" />
        </fun>
        <params>
          <arg value=""b1"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""bu(&quot;clickevent&quot;,&quot;Click&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""bu"" con=""var"" />
        </fun>
        <params>
          <arg value=""clickevent"" con=""str"" />
          <arg value=""Click"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""bu(&quot;text&quot;,&quot;click&quot;);"">
      <arg con=""fun"">
        <fun>
          <arg value=""bu"" con=""var"" />
        </fun>
        <params>
          <arg value=""text"" con=""str"" />
          <arg value=""click"" con=""str"" />
        </params>
      </arg>
    </usefun_s>
    <usefun_s str=""page()(bu);"">
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
          <arg value=""bu"" con=""var"" />
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
  <deffun funname=""Click"" params=""p,e"" isref=""False"">
    <var_s varname=""res"" str=""var res = IO.Input(&quot;请输入&quot;,&quot;输入姓名&quot;,&quot;xiaoming&quot;);"" />
    <getres_s str=""var res = IO.Input(&quot;请输入&quot;,&quot;输入姓名&quot;,&quot;xiaoming&quot;);"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Input"" con=""var"" />
        </fun>
        <params>
          <arg value=""请输入"" con=""str"" />
          <arg value=""输入姓名"" con=""str"" />
        </params>
      </arg>
    </getres_s>
    <usefun_s str=""Page.SetTitle(p,res);"">
      <arg con=""fun"">
        <fun>
          <arg value=""Page.SetTitle"" con=""var"" />
        </fun>
        <params>
          <arg value=""p"" con=""var"" />
          <arg value=""res"" con=""var"" />
        </params>
      </arg>
    </usefun_s>
  </deffun>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("UWP_Xamarin");
            LoadApplication(new GTXAM.App());
        }

    }
}
