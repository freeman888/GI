using GTXAM;
using System.Xml;
using Xamarin.Forms.Platform.WPF;

namespace HelloWPF.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
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

            
            Xamarin.Forms.Forms.Init();
            LoadApplication(new GTXAM.App());

        }
    }
}