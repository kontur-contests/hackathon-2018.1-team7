using Android.App;
using Android.OS;
using Android.Widget;
using CocosSharp;
using GameLogic;
using Xamarin.Forms;
using Button = Android.Widget.Button;

namespace DevUiAndroidV2
{
    [Activity(Label = "PrepareView")]
    public class PrepareView : Activity
    {
        private SeekBar _rowsSeekBar;
        private SeekBar _rankSeekBar;
        private TextView _totalUnitsEditText;
        private TextView _totalInSquadEditText;
        private LinearLayout _topLayout;
        private LinearLayout _cocosLayout;
        private WorldsGenerator WorldGen;
        private Button _somethingButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            WorldGen = WorldsGenerator.GetDefault(150, 100);
            SetContentView(Resource.Layout.PrepareView);
            _somethingButton = FindViewById<Button>(Resource.Id.doSomethingButton);
            _rowsSeekBar = FindViewById<SeekBar>(Resource.Id.rowsSeekBar);
            _rankSeekBar = FindViewById<SeekBar>(Resource.Id.rankSeekBar);
            _totalUnitsEditText = FindViewById<TextView>(Resource.Id.totalUnits);
            _totalInSquadEditText = FindViewById<TextView>(Resource.Id.totalInSquad);
            _topLayout = FindViewById<LinearLayout>(Resource.Id.topLayout);
            _cocosLayout = FindViewById<LinearLayout>(Resource.Id.cocosLayout);
            _rowsSeekBar.Max = 15;
            _rankSeekBar.Max = 15;
            _rowsSeekBar.ProgressChanged += _rankSeekBar_ProgressChanged;
            _rankSeekBar.ProgressChanged += _rankSeekBar_ProgressChanged;
            _somethingButton.Click += _somethingButton_Click;
            // Create your application here
        }

        private void _somethingButton_Click(object sender, System.EventArgs e)
        {
        }

        private void _rankSeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            _totalInSquadEditText.Text = (_rankSeekBar.Progress * _rowsSeekBar.Progress).ToString();
        }
    }
}