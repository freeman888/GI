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

namespace GTWPF.GTWPFFunctions._function_IO
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
        string content = "";
        bool done = false;
        public async Task<string> GetInput(string title = "Input",string tips = "")
        {
            Show();
            Title = title;
            Tips.Content = tips;
            
            await Task.Run(() =>
                {
                    while (!done) ;
                    return 1;
                });
            return content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            content = InputBox.Text;
            Close();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            done = true;
        }
    }
}
