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
            xmlDocument.Load("d:\\projects\\freestudio\\FreeStudio\\FreeStudio\\source\\code.xml");
            GTXAMInfo.Codes.Add(xmlDocument);
            GTXAMInfo.SetPlatform("WPF_Xamarin");


            Xamarin.Forms.Forms.Init();
            LoadApplication(new GTXAM.App());

        }
    }
}