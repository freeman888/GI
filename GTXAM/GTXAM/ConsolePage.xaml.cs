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
        public ConsolePage()
        {

            InitializeComponent();
            
            Task.Run(() =>
            {
                Thread.Sleep(10);
                Device.BeginInvokeOnMainThread(() =>
                {
                    _function_Thread_override_.Load();
                    var res = new System.Collections.Generic.Dictionary<string, GI.Function.Head>
                        {
                            {"IO" ,new GTXAMFunctions.GTXAMFunction.IO_Head()},
                            {"Page",new GTXAMFunctions. GTXAMFunction.Page_Head()},
                            {"Control",new GTXAMFunctions.GTXAMFunction.Control_Head() },
                            {"Alien",new GTXAMFunctions.GTXAMFunction.Alien_Head() }
                        

                        };
                    GI.Gasoline.StartGas(res, GTXAM.GTXAMInfo.Codes);
                });
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