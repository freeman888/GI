using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Xml;

namespace GTXAM.Droid
{
    [Activity(Label = "GTXAM", Icon = "@mipmap/icon",MainLauncher =true, Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            var input = Assets.Open("code.xml");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(input);
            GTXAM.GTXAMInfo.Codes = xmlDocument;
            GTXAM.GTXAMInfo.SetPlatform("Android_Xamarin");
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

