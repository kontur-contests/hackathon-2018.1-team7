using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace DevUiAndroidV2
{
    [Activity(Label = "Warxels", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            FindViewById<Button>(Resource.Id.startGameButton).Click += MainActivity_Click;
        }

        private void MainActivity_Click(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(PrepareView)));
        }
    }
}

