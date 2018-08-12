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
    [Activity(Label = "End Menu", MainLauncher = false)]
    public class End : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.End);

            PressButtonRetry();
        }

        public Button btnRetry;

        public void PressButtonRetry()
        {
            btnRetry = FindViewById<Button>(Resource.Id.btnRetry);

            btnRetry.Click += delegate
            {
                StartActivity(typeof(MainActivity));

            };
        }
    }
}