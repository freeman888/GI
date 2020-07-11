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

            //    InitializeComponent();
            //    MainApp = this;
            //    MainPage = new NavigationPage(new ConsolePage());

            var stack = new StackLayout()
            {
            };
            stack.Children.Add(new Button
            {
                Text = "Hello",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

            });
            Button button = new Button
            {
                Text = "World"
            };
            button.Clicked += (o, e) =>
            {
                MainPage.Navigation.PushAsync(new ContentPage { Title = "ok" });
            };
            stack.Children.Add(button);
            MainPage = new NavigationPage(new MasterDetailPage
            {
                Master = new ContentPage { Title = "fuck", Content = new ListView { ItemsSource = new string[] { "hello", "world" } } },
                Detail = new ContentPage { Content = stack }
            });

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
