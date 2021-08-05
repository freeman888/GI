using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using GI;

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

            Stream stream = new FileStream("D:\\projects\\Libs\\HashTable\\debug\\HashTable.gaa", FileMode.Open);
            ZipArchive zipArchive = new ZipArchive(stream);

            GI.GStream.gaas.Add("App1", zipArchive);
            var entry = zipArchive.GetEntry("HashTable" + "/information.xml");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(entry.Open());
            var type = xmlDocument.ChildNodes[0].GetAttribute("source");
            if (type == "gas")
            {
                XmlDocument code = new XmlDocument();
                code.Load(zipArchive.GetEntry("HashTable" + "/source/code.xml").Open());
                GI.Gasoline.Loadgasxml(code);
            }

            GTWPF.MainWindow mainWindow = new GTWPF.MainWindow();
            mainWindow.Show();


        }
        

    }
}
