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
  <get value=""Math"" />
  <deffun funname=""Main"" params=""args"" isref=""False"">
    <var_s varname=""res"" str=""var res = IO.Input();"" />
    <getres_s str=""var res = IO.Input();"">
      <arg value=""res"" con=""var"" />
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Input"" con=""var"" />
        </fun>
        <params />
      </arg>
    </getres_s>
    <usefun_s str=""IO.Write(res);"">
      <arg con=""fun"">
        <fun>
          <arg value=""IO.Write"" con=""var"" />
        </fun>
        <params>
          <arg value=""res"" con=""var"" />
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