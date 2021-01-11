using System;
using System.Collections.Generic;
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


            XmlDocument code = new XmlDocument();
            code.Load("X:\\projects\\freestudio\\App1\\App1\\source\\code.xml");
            GI.Gasoline.Loadgasxml(code);
        
            GTWPF.MainWindow mainWindow = new GTWPF.MainWindow();
            mainWindow.Show();


        }
    }
}
