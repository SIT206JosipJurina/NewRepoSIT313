using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Android;

namespace SIT313_Assignment_1
{
    [Activity(Label ="Main Menu", MainLauncher = false )]
    public class MainMenu : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            PressButtonPlay();
            PressButtonExit();
            
        }

        public Button btnPlay, btnExit;

        public void PressButtonPlay()
        {
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
           
            btnPlay.Click += delegate
            {
                StartActivity(typeof(MainActivity));
                
            };
        }
        public void PressButtonExit()
        {
            btnExit = FindViewById<Button>(Resource.Id.btnExit);
            btnExit.Click += delegate
            {
                Java.Lang.JavaSystem.Exit(0);
            };
        }
        
    }
}