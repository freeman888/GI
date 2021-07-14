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
using System.Windows.Shapes;

namespace GTWPF.GwpfLib.IO
{
    /// <summary>
    /// Input.xaml 的交互逻辑
    /// </summary>
    public partial class Input : Window
    {
        public Input()
        {
            InitializeComponent();
        }
        public string content = "";
        public static  bool done = false;
        public void SetContent(string title,string tips)
        {
            Tips.Content = tips;
            Title = title;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            content = InputBox.Text;
            done = true;
            Close();

        }

        
    }
}
