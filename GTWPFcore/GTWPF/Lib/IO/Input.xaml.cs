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
        public string content = "";
        public static bool done = false;
        public void SetContent(string title, string tips)
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
