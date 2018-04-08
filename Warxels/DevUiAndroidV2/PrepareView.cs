using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using GameLogic;
using GameLogic.Helper;
using Java.Util;
using Xamarin.Forms;
using Button = Android.Widget.Button;
using View = Android.Views.View;

namespace DevUiAndroidV2
{
    [Activity(Label = "Warxels")]
    public class PrepareView : Activity
    {
        private SeekBar _rowsSeekBar;
        private SeekBar _rankSeekBar;
        private TextView _totalUnitsEditText;
        private TextView _totalInSquadEditText;
        private TextView _rowText;
        private TextView _rankText;
        private LinearLayout _topLayout;
        private LinearLayout _cocosLayout;
        private WorldsGenerator WorldGen;
        private Button _somethingButton;
        private MyView _view;
        private Spinner _spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PrepareView);
            _somethingButton = FindViewById<Button>(Resource.Id.doSomethingButton);
            _rowsSeekBar = FindViewById<SeekBar>(Resource.Id.rowsSeekBar);
            _rankSeekBar = FindViewById<SeekBar>(Resource.Id.rankSeekBar);
            _totalUnitsEditText = FindViewById<TextView>(Resource.Id.totalUnits);
            _totalInSquadEditText = FindViewById<TextView>(Resource.Id.totalInSquad);
            _rowText = FindViewById<TextView>(Resource.Id.rowText);
            _rankText = FindViewById<TextView>(Resource.Id.rankText);
            _topLayout = FindViewById<LinearLayout>(Resource.Id.topLayout);
            _cocosLayout = FindViewById<LinearLayout>(Resource.Id.cocosLayout);
            _spinner = FindViewById<Spinner>(Resource.Id.squadTypeSpinner);
            _view = new MyView(_cocosLayout.Context);
            _cocosLayout.AddView(_view);
            _rowsSeekBar.Max = 15;
            _rankSeekBar.Max = 15;
            _rowsSeekBar.ProgressChanged += _rankSeekBar_ProgressChanged;
            _rankSeekBar.ProgressChanged += _rankSeekBar_ProgressChanged;
            _somethingButton.Click += _somethingButton_Click;
            _totalInSquadEditText.Text = (_rankSeekBar.Progress * _rowsSeekBar.Progress).ToString();
            _totalUnitsEditText.Text = _view.Army.Size.ToString();
            Forms.Init(this, savedInstanceState);
            if (Intent.GetBooleanExtra("ISLOAD", false))
            {
                WorldGen = WorldsGenerator.GetDefault(MyView.SIZE * 3 / 2, MyView.SIZE);
                if (WorldGen.GetWorld().Width != MyView.SIZE)
                    WorldGen = null;
                else
                {
                    try
                    {
                        WorldGen.LoadUnitsFromFile("units.units", true);
                    }
                    catch 
                    {
                        WorldGen = null;
                    }
                }
            }
            _view.Touch += _view_Touch;
        }

        private void _view_Touch(object sender, View.TouchEventArgs e)
        {
            if (WorldGen != null)
            {
                _view.SetLoadedWorld(WorldGen.GetWorld());
                _view.Touch -= _view_Touch;
                return;
            }
            if(e.Event.Action== MotionEventActions.Up)
            {
                _view.TapTap(e.Event.GetX(), e.Event.GetY(), _rowsSeekBar.Progress, _rankSeekBar.Progress, GetUnitType());
                _totalInSquadEditText.Text = (_rankSeekBar.Progress * _rowsSeekBar.Progress).ToString();
                _totalUnitsEditText.Text = _view.Army.Size.ToString();
                UpdateSelectors();
            }
        }

        private void ShowResults(BattleView view)
        {
            SetContentView(Resource.Layout.ResultView);
            var yourDamage = FindViewById<TextView>(Resource.Id.yourDamageText);
            var enemyDamage = FindViewById<TextView>(Resource.Id.enemyDamageText);
            var winner = FindViewById<TextView>(Resource.Id.winnerText);
            yourDamage.Text += view.CountRedDead;
            enemyDamage.Text += view.CountBlueDead;
            winner.Text += view.CountRedDead < view.CountBlueDead ? "Красные" : "Синие";
        }

        private UnitType GetUnitType()
        {
            switch(_spinner.SelectedItem.ToString())
            {
                case "Мечник":
                    return UnitType.SwordsMan;
                case "Лучник":
                    return UnitType.Archer;
                case "Конь текучий":
                    return UnitType.HorseMan;
            }
            return UnitType.SwordsMan;
        }

        private void _somethingButton_Click(object sender, System.EventArgs e)
        {
            var view = new BattleView(this, WorldGen == null ? _view.Army.GenerateWorld() : WorldGen.GetWorld());

            SetContentView(view);

            StartTimer(TimeSpan.FromMilliseconds(view.Delay), () =>
            {
                view.Invalidate();
                if (view.EndGame)
                    ShowResults(view);
                return !view.EndGame;
            });

            view.World.SaveUnits("units.units", true);
            view.World.SaveTerrain("terr.terr", true);
        }
        
        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            var handler = new Handler(Looper.MainLooper);
            handler.PostDelayed(() =>
            {
                if (callback())
                    StartTimer(interval, callback);

                handler.Dispose();
                handler = null;
            }, (long)interval.TotalMilliseconds);
        }
        private void UpdateSelectors()
        {
            UpdateSelectors(_rowsSeekBar);
            UpdateSelectors(_rankSeekBar);
        }
        private void UpdateSelectors(object sender)
        {
            var army = _view.Army.MaxSizeArmy - _view.Army.Size;
            if (sender == _rowsSeekBar)
            {
                _rankSeekBar.Max = Math.Min(army / (_rowsSeekBar.Progress == 0 ? 1 : _rowsSeekBar.Progress), MyView.SIZE / 2);
                _rankSeekBar.Progress = Math.Min(_rankSeekBar.Max, _rankSeekBar.Progress);
                _rowText.Text = "Число рядов: " + _rowsSeekBar.Progress;
            }
            else
            {
                _rowsSeekBar.Max = Math.Min(army / (_rankSeekBar.Progress == 0 ? 1 : _rankSeekBar.Progress), MyView.SIZE);
                _rowsSeekBar.Progress = Math.Min(_rowsSeekBar.Max, _rowsSeekBar.Progress);
                _rankText.Text = "Число шеренг: " + _rankSeekBar.Progress;
            }
            _totalInSquadEditText.Text = (_rankSeekBar.Progress * _rowsSeekBar.Progress).ToString();
            _totalUnitsEditText.Text = _view.Army.Size.ToString();
        }

        private void _rankSeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            UpdateSelectors(sender);
        }
    }
}