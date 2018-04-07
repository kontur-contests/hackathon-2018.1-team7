using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace DevUIAndroid
{
    [Activity(Label = "MainMenu"
        , MainLauncher = true)]
    public class MainMenu : Activity
    {
        private Button startGameButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenu);

            startGameButton = FindViewById<Button>(Resource.Id.startGameButton);
            startGameButton.Click += StartGameButton_Click;
            // Create your application here
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Program));
            StartActivity(intent);
        }
    }
}