using System;
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
        private CCGameView _gameView;
        private WorldsGenerator WorldGen;
        private Button _somethingButton;
        private CocosSharpView gameView;

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
            _gameView = FindViewById<CCGameView>(Resource.Id.cCGameView);
            _rowsSeekBar.Max = 15;
            _rankSeekBar.Max = 15;
            _rowsSeekBar.ProgressChanged += _rankSeekBar_ProgressChanged;
            _rankSeekBar.ProgressChanged += _rankSeekBar_ProgressChanged;
            _somethingButton.Click += _somethingButton_Click;
        }

        private void _somethingButton_Click(object sender, System.EventArgs e)
        {
            CCScene gameScene = new CCScene(_gameView);

            // This will set the world bounds to be (0,0, w, h)
            // CCSceneResolutionPolicy.ShowAll will ensure that the aspect ratio is preserved
            gameScene.AddLayer(new GameLayer());
            _gameView.RunWithScene(gameScene);
            _gameView.StartGame();
        }

        private void _rankSeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            _totalInSquadEditText.Text = (_rankSeekBar.Progress * _rowsSeekBar.Progress).ToString();
        }
    }

    class GameLayer : CCLayer
    {
        protected override void AddedToScene()
        {
            base.AddedToScene();
            
            this.ContentSize = new CCSize(100, 100);
            CCLabel label = new CCLabel("Test", "arial", 22);
            label.Position = new CCPoint(50, 50);
            AddChild(label);
        }
    }
}