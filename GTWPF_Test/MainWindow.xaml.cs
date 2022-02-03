using GI;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Xml;

namespace GTWPF_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();



            Hide();

            /*
             * 先加载gasoline代码，然后加载gi和平台代码，最后拉起main函数
             */
            Stream stream = new FileStream("E:\\projects\\freestudio\\App1\\debug\\App1.gaa", FileMode.Open);
            ZipArchive zipArchive = new ZipArchive(stream);

            GI.GStream.gaas.Add("App1", zipArchive);
            var entry = zipArchive.GetEntry("App1" + "/information.xml");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(entry.Open());
            var type = xmlDocument.ChildNodes[0].GetAttribute("source");
            if (type == "gas")
            {
                XmlDocument code = new XmlDocument();
                code.Load(zipArchive.GetEntry("App1" + "/source/code.xml").Open());
                GI.Gasoline.Loadgasxml(code);
            }

            GI.Gasoline.libs.Add("Test", new CompileLibTest());

            GTWPF.MainWindow mainWindow = new GTWPF.MainWindow();
            mainWindow.Show();


        }


    }
}
