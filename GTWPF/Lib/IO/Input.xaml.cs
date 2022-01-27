using System;
using System.Threading.Tasks;
using System.Windows;

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
        string content = "";
        bool done = false;
        public async Task<string> GetInput(string title = "Input", string tips = "")
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
