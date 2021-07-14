using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using GI;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GTXAM
{
    public partial class App : Application
    {

        public static App MainApp;
        public App()
        {

            InitializeComponent();
            MainApp = this;



            MainPage = new NavigationPage(new ConsolePage());

            //var bu = new Button { Text = "ClickMe", FontSize = 222 };
            //MainPage = new ContentPage
            //{
            //    Title = "test",
            //    Content = new Grid
            //    {
            //        Children =
            //        {
            //            bu
            //        }
            //    }
            //};


        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
