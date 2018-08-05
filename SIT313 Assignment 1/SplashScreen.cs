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

namespace SIT313_Assignment_1
{
    [Activity(Label = "Josip'sLogoQuiz", MainLauncher = true, NoHistory =true, Theme = "@style/theme.Splash")]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));

            // Create your application here
        }
    }
}