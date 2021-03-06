﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace SIT313_Assignment_1.Adapter
{
    public class GridViewSuggestAdapter : BaseAdapter
    {
        private List<string> suggestSource;
        private Context context;
        private MainActivity mainActivity;

        public GridViewSuggestAdapter(List<string> suggestSource, Context context, MainActivity mainActivity)
        {
            this.suggestSource = suggestSource;
            this.context = context;
            this.mainActivity = mainActivity;
        }
        public override int Count
        {
            get { return suggestSource.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Button button;
            if (convertView == null)
            {            
                if (suggestSource[position].Equals("null"))
                {
                    button = new Button(context);
                    button.LayoutParameters = new GridView.LayoutParams(85, 85);
                    button.SetPadding(8, 8, 8, 8);
                    button.SetBackgroundColor(Color.DarkGray);

                }
                else
                {
                    button = new Button(context);
                    button.LayoutParameters = new GridView.LayoutParams(85, 85);
                    button.SetPadding(8, 8, 8, 8);
                    button.SetBackgroundColor(Color.DarkGray);
                    button.SetTextColor(Color.Yellow);
                    button.Text = suggestSource[position];
                    button.Click += delegate
                    {
                        //here is when the user clicks on char
                        //convert char array to string
                        string answer = new string(mainActivity.answer);
                        if (answer.Contains(suggestSource[position]))
                        {
                            char compare = suggestSource[position][0]; //this gets char from string
                            for(int i=0; i<answer.Length; i++)
                            {
                                if(compare == answer[i])
                                {
                                    Common.Common.user_submit_answer[i] = compare;
                                }
                            } 

                           
                            //update UI
                            GridViewAnswerAdapter answerAdapter = new GridViewAnswerAdapter(Common.Common.user_submit_answer, context);
                            mainActivity.gvAnswer.Adapter = answerAdapter;
                            answerAdapter.NotifyDataSetChanged();

                            //Remove characters from suggest source
                            mainActivity.suggestSource[position] = "null";
                            mainActivity.suggestAdapter = new GridViewSuggestAdapter(mainActivity.suggestSource, context, mainActivity);
                            mainActivity.gvSuggest.Adapter = mainActivity.suggestAdapter;
                            mainActivity.suggestAdapter.NotifyDataSetChanged();
                        }
                        else
                        {
                            //Remove characters from suggest source
                            mainActivity.suggestSource[position] = "null";
                            mainActivity.suggestAdapter = new GridViewSuggestAdapter(mainActivity.suggestSource, context, mainActivity);
                            mainActivity.gvSuggest.Adapter = mainActivity.suggestAdapter;
                            mainActivity.suggestAdapter.NotifyDataSetChanged();
                        }
                };

                }
            }
            else
            {
                button = (Button)convertView;
                
            }
            return button;
        }
    }
}