using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace DevUiAndroidV2
{
    [Activity(Label = "Warxels", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _startGameButton;
        private Button _loadLastGameButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _startGameButton = FindViewById<Button>(Resource.Id.startGameButton);
            _startGameButton.Click += MainActivity_Click;
            _loadLastGameButton = FindViewById<Button>(Resource.Id.loadLastGame);
            _loadLastGameButton.Click += MainActivity_Click;
        }

        private void MainActivity_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(PrepareView));
            intent.PutExtra("ISLOAD", sender == _loadLastGameButton);
            StartActivity(intent);
        }
    }
}

