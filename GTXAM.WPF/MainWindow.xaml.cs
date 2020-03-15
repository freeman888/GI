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
<code minversion=""1902"">
  <get value=""IO"" />
  <deffun funname=""Main"" params=""args"" isref=""False"">
    <usefun_s str=""IO.WriteLine(IO.Input());"">
      <arg con=""fun"">
        <fun>
          <arg value=""IO.WriteLine"" con=""var"" />
        </fun>
        <params>
          <arg con=""fun"">
            <fun>
              <arg value=""IO.Input"" con=""var"" />
            </fun>
            <params />
          </arg>
        </params>
      </arg>
    </usefun_s>
  </deffun>
</code>");
            GTXAMInfo.Codes = xmlDocument;
            GTXAMInfo.SetPlatform("WPF_Xamarin");
            Xamarin.Forms.Forms.Init();
            LoadApplication(new GTXAM.App());
        }
    }
}