using System;
using System.IO.Compression;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using GI;

namespace GTXAM.Droid
{
    [Activity(Label = "GTXAM", Icon = "@mipmap/icon",MainLauncher =true, Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            var input = Assets.Open("main");
            string text = "";
            using(var streamreader = new StreamReader(input))
            {
                text = streamreader.ReadToEnd();
            }


            Loaddependences(text);
            GTXAM.GTXAMInfo.SetPlatform("Android_Xamarin");
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            App application = new App();
            Xamarin.Essentials.Platform.Init(this.Application);
            LoadApplication(application);
        }


        void Loaddependences(string name)
        {
            if (loadeddep.IndexOf(name) == -1)
            {
                loadeddep.Add(name);
                var i = name;
                Stream stream = Assets.Open(name + ".gaa");
                ZipArchive zipArchive = new ZipArchive(stream);

                GI.GStream.gaas.Add(i, zipArchive);
                var entry = zipArchive.GetEntry(i + "/information.xml");

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(entry.Open());
                var type = xmlDocument.ChildNodes[0].GetAttribute("source");
                if (type == "gas")
                {
                    XmlDocument code = new XmlDocument();
                    code.Load(zipArchive.GetEntry(i + "/source/code.xml").Open());
                    GI.Gasoline.Loadgasxml(code);
                }
                foreach (System.Xml.XmlNode deps in xmlDocument.ChildNodes[0].ChildNodes[0].ChildNodes)
                {
                    Loaddependences(deps.GetAttribute("name"));
                }
            }

            else return;
        }
        List<string> loadeddep = new List<string>();


    }
}

