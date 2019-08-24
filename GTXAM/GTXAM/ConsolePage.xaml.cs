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
                    var res = new System.Collections.Generic.Dictionary<string, GI.Function.Head>
                        {
                            {"IO" ,new GTXAMFunctions.GTXAMFunction.IO_Head()},
                            {"Page",new GTXAMFunctions. GTXAMFunction.Page_Head()},
                            {"Control",new GTXAMFunctions.GTXAMFunction.Control_Head() },

                        };
                    GI.Gasoline.StartGas(res, GTXAM.GTXAMInfo.Codes);
                });
            });
            OutputLabel.Text += "Gasoline for GTXAM Version " + GI.GIInfo.GIVersion.ToString() + Environment.NewLine;
        }
        



        public async void ConsoleWrite(string str)
        {
            OutputLabel.Text += str;
            await OutputScroll.ScrollToAsync(OutputLabel, ScrollToPosition.End, true);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}