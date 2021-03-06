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
    public class GridViewAnswerAdapter : BaseAdapter
    {
        private char[] answerCharacters;
        private Context context;

        public GridViewAnswerAdapter(char[] answerCharacter, Context context)
        {
            this.answerCharacters = answerCharacter;
            this.context = context;

        }

        public override int Count
        {
            get {
                return answerCharacters.Length;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return answerCharacters[position];
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
                button = new Button(context);
                button.LayoutParameters = new GridView.LayoutParams(85, 85);
                button.SetPadding(8, 8, 8, 8);
                button.SetBackgroundColor(Color.DarkGray);
                button.SetTextColor(Color.Yellow);
                button.Text = Convert.ToString(answerCharacters[position]);
            }
            else
            {
                button = (Button)convertView;
                
            }
            return button;
        }
    }

}