using System;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Views;
using GameLogic;

namespace DevUiAndroidV2
{
    class BattleView : View
    {
        public bool EndGame => _lastMoveAgo > 50;
        public int Delay { get; } = 10;
        public IWorld World { get; }
        private const int SIZE = MyView.SIZE;
        private int _lastMoveAgo=0;
        private int step;
        private Paint marshPaint = new Paint { Color = new Color(0, 0, 255, 64) };
        private Paint projectilePen = new Paint { Color = Color.Brown };

        public int CountBlueDead { get; private set; } = 0;
        public int CountRedDead { get; private set; } = 0;


        private Paint[] TeamAPens = new Paint[] {
            new Paint{Color = Color.Red, Alpha = 50},
            new Paint{Color = Color.Red, Alpha = 100},
            new Paint{Color = Color.Red, Alpha = 150},
            new Paint{Color = Color.Red, Alpha = 200},
            new Paint{Color = Color.Red, Alpha = 255}
        };

        private Paint[] TeamBPens = new Paint[] {
            new Paint{Color = Color.Blue, Alpha = 50},
            new Paint{Color = Color.Blue, Alpha = 100},
            new Paint{Color = Color.Blue, Alpha = 150},
            new Paint{Color = Color.Blue, Alpha = 200},
            new Paint{Color = Color.Blue, Alpha = 255}
        };

        private Paint[] TeamASolidPens = new Paint[] {
            new Paint{Color = Color.Red, Alpha = 50},
            new Paint{Color = Color.Red, Alpha = 100},
            new Paint{Color = Color.Red, Alpha = 150},
            new Paint{Color = Color.Red, Alpha = 200},
            new Paint{Color = Color.Red, Alpha = 255}
        };

        private Paint[] TeamBSolidPens = new Paint[] {
            new Paint{Color = Color.Blue, Alpha = 50},
            new Paint{Color = Color.Blue, Alpha = 100},
            new Paint{Color = Color.Blue, Alpha = 150},
            new Paint{Color = Color.Blue, Alpha = 200},
            new Paint{Color = Color.Blue, Alpha = 255}
        };

        public BattleView(Context context, IWorld world) : base(context)
        {
            World = world;
            foreach (var p in TeamASolidPens)
            {
                p.SetStyle(Paint.Style.Fill);
            }
            foreach (var p in TeamBSolidPens)
            {
                p.SetStyle(Paint.Style.Fill);
            }

            foreach (var p in TeamAPens)
            {
                p.SetStyle(Paint.Style.Stroke);
            }
            foreach (var p in TeamBPens)
            {
                p.SetStyle(Paint.Style.Stroke);
            }
        }

        private void DrawTerrain(Canvas canvas)
        {
            for (int i = 0; i < World.Terrain.GetLength(0); i++)
            {
                for (int j = 0; j < World.Terrain.GetLength(1); j++)
                {
                    switch (World.Terrain[i, j])
                    {
                        case 1:
                            canvas.DrawRect(i * step, j * step, (i + 1) * step, (j + 1) * step, marshPaint);
                            break;
                        default: break;
                    }
                }
            }
        }
        private void DrawUnits(Canvas canvas)
        {
            foreach (var unit in World.Army.GetUnits())
            {
                var healthPercentageIndex = (int)Math.Floor(unit.GetHealthPercentage() / 25);
                switch (unit.UnitType)
                {
                    case UnitType.SwordsMan:
                        canvas.DrawOval(unit.X * step, unit.Y * step, (unit.X + 1) * step, (unit.Y + 1) * step, unit.Team == Team.Red ? TeamAPens[healthPercentageIndex] : TeamBPens[healthPercentageIndex]); break;
                    case UnitType.HorseMan:
                        canvas.DrawRect(unit.X * step, unit.Y * step, (unit.X + 1) * step, (unit.Y + 1) * step, unit.Team == Team.Red ? TeamAPens[healthPercentageIndex] : TeamBPens[healthPercentageIndex]); break;
                    case UnitType.Archer:
                        canvas.DrawOval(unit.X * step, unit.Y * step, (unit.X + 1) * step, (unit.Y + 1) * step, unit.Team == Team.Red ? TeamASolidPens[healthPercentageIndex] : TeamBSolidPens[healthPercentageIndex]); break;
                }
            }
        }

        private void DrawProjectiles(Canvas canvas)
        {
            foreach (var projectile in World.GetProjectiles())
            {
                canvas.DrawOval(projectile.X * step, projectile.Y * step, projectile.X * step + step / 2.0f,
                    projectile.Y * step + step / 2.0f, projectilePen);
            }
        }

        public override void Draw(Canvas canvas)
        {
            step = Right / SIZE;

            if (!EndGame)
            {

                var result = World.DoTick();
                if (result.WasMoves)
                    _lastMoveAgo = 0;
                else
                    _lastMoveAgo++;
                CountBlueDead += result.DeadUnits.Count(c => c.Team == Team.Blue);
                CountRedDead += result.DeadUnits.Count(c => c.Team == Team.Red);
            }
            canvas.DrawARGB(255, 255, 255, 255);

            DrawTerrain(canvas);
            DrawUnits(canvas);
            DrawProjectiles(canvas);
        }
    }
}