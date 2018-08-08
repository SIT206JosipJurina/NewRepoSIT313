using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using System;
using SIT313_Assignment_1.Adapter;
using System.Linq;

namespace SIT313_Assignment_1
{
    [Activity(Label = "Josip'sLogoQuiz", MainLauncher = false, Icon = "@drawable/icon", Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {

        public List<string> suggestSource = new List<string>();
        public GridViewAnswerAdapter answerAdapter;
        public GridViewSuggestAdapter suggestAdapter;

        public Button btnSubmit;
        public GridView gvAnswer, gvSuggest;

        public ImageView imgLogo;

        int[] image_list =
        {
            Resource.Drawable.facebook, Resource.Drawable.google, Resource.Drawable.instagram, Resource.Drawable.linkin,
            Resource.Drawable.reddit, Resource.Drawable.snapchat, Resource.Drawable.spotify, Resource.Drawable.tumblr,
            Resource.Drawable.twitter, Resource.Drawable.yahoo, Resource.Drawable.youtube
        };

        public char[] answer;
        string correct_answer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);        
            SetContentView(Resource.Layout.activity_main);

            InitViews();
            
        }

        private void InitViews()
        {
            gvAnswer = FindViewById<GridView>(Resource.Id.gvAnswer);
            gvSuggest = FindViewById<GridView>(Resource.Id.gvSuggest);

            imgLogo = FindViewById<ImageView>(Resource.Id.imgLogo);

            SetupList();

            btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            btnSubmit.Click += delegate
            {
                // here we will convert char array to string
                string result = new string(Common.Common.user_submit_answer);

                //if user gets correct answer just reset the game and go next question
                if (result.Equals(correct_answer))
                {
                    Toast.MakeText(ApplicationContext, "Finish ! This is " + result.ToUpper(), ToastLength.Short).Show();        
                    //reset
                    Common.Common.user_submit_answer = new char[correct_answer.Length];

                    //Update UI
                    GridViewAnswerAdapter answerAdapter = new GridViewAnswerAdapter(SetupNullList(), this);
                    gvAnswer.Adapter = answerAdapter;
                    answerAdapter.NotifyDataSetChanged();

                    GridViewSuggestAdapter suggestAdapter = new GridViewSuggestAdapter(suggestSource, this, this);
                    gvSuggest.Adapter = suggestAdapter;
                    suggestAdapter.NotifyDataSetChanged();

                    SetupList();

                }
                else { 
                
                    Toast.MakeText(this, "Incorrect!!!", ToastLength.Short).Show();
                }
                
            };

        }

        private char[] SetupNullList()
        {
            char[] result = new char[answer.Length];
            return result;
        }

        private void SetupList()
        {
            //Random logo
            Random random = new Random();
            int imageSelected = image_list[random.Next(image_list.Length)];
            imgLogo.SetImageResource(imageSelected);

            correct_answer = Resources.GetResourceName(imageSelected);
            correct_answer = correct_answer.Substring(correct_answer.LastIndexOf("/") + 1);

            //string to char array
            answer = correct_answer.ToCharArray();

            Common.Common.user_submit_answer = new char[answer.Length];

            //Add Answer character to List
            suggestSource.Clear();
            foreach (char item in answer) { 
            
                suggestSource.Add(Convert.ToString(item));
            }
            // random characters from the alphabet list and add to the list
            for(int i= answer.Length; i<answer.Length*2; i++) {
                suggestSource.Add(Common.Common.alphabet_characters[random.Next(Common.Common.alphabet_characters.Length)]);                          
                
            }
            //Sort list
            suggestSource = suggestSource.OrderBy(x => Guid.NewGuid()).ToList();

            //set apdater for the grid view
            answerAdapter = new GridViewAnswerAdapter(SetupNullList(), this);
            suggestAdapter = new GridViewSuggestAdapter(suggestSource, this, this);

            answerAdapter.NotifyDataSetChanged();
            suggestAdapter.NotifyDataSetChanged();

            gvAnswer.Adapter = answerAdapter;
            gvSuggest.Adapter = suggestAdapter;
        }
    }
}

