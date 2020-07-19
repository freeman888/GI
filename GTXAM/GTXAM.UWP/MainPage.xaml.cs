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
<code minversion=""2007"">
  <lib name=""Program"">
    <get value=""IO"" />
    <deffun funname=""Main"" params=""args"" isref=""False"">
      <usefun_s str=""Message(&quot;hello&quot;);"">
        <arg con=""fun"">
          <fun>
            <arg value=""Message"" con=""var"" />
          </fun>
          <params>
            <arg value=""hello"" con=""str"" />
          </params>
        </arg>
      </usefun_s>
    </deffun>
  </lib>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("UWP_Xamarin");
            LoadApplication(new GTXAM.App());
        }

    }
}
