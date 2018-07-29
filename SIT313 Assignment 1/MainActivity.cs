using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using System;
using SIT313_Assignment_1.Adapter;

namespace SIT313_Assignment_1
{
    [Activity(Label = "Josip'sLogoQuiz", MainLauncher = true, Icon = "drawable/icon", Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {

        public List<string> suggestSource = new List<string>();
        public GridViewAnswerAdapter answerAdapater;
        public GridViewSuggestAdapter suggestAdapter;

        public Button btnSubmit;
        public GridView gvAnswer, gvSuggest;

        public ImageView imgLogo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);        
            SetContentView(Resource.Layout.activity_main);

            InitViews();
            
        }

        private void InitViews()
        {
           
        }
    }
}

