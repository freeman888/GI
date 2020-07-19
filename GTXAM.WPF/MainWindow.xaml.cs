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
            GTXAMInfo.SetPlatform("WPF_Xamarin");
            Xamarin.Forms.Forms.Init();
            LoadApplication(new GTXAM.App());
        }
    }
}