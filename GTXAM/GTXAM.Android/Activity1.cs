using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GTXAM.Droid
{
    [Activity(Label = "Activity1",Theme = "@style/SplashTheme",Icon ="@mipmap/icon")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            StartActivity(typeof(MainActivity));
            this.Finish();
        }
    }
}