using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTXAM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsolePage : ContentPage
    {
        static ConsolePage()
        {
            Task.Run(() =>
            {
                Thread.Sleep(10);
                Device.BeginInvokeOnMainThread(() =>
                {
                    GI.Gasoline.Loadgasxml(GTXAMInfo.Codes);
                    Lib._function_Thread_override_.Load();

                    GI.Gasoline.StartGas(new System.Collections.Generic.Dictionary<string, GI.Lib.ILib> {
                     {"IO",new Lib.IO_Lib() },
                     {"Page",new Lib.Page_Lib() },
                     {"Control",new Lib.Control_Lib() }

                    });
                    

                });
            }).Wait();
        }
        public ConsolePage()
        {

            InitializeComponent();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(10);
                await GI.Gasoline.StartMain();
            });


            OutputLabel.Text += "Gasoline for GTXAM Version " + GI.GIInfo.GIVersion.ToString() + Environment.NewLine;
        }
        



        public  void ConsoleWrite(string str)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                OutputLabel.Text += str;
                OutputScroll.ScrollToAsync(OutputLabel, ScrollToPosition.End, true);
            });
        }
        
    }
}