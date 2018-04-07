using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using GameLogic;

namespace DevUiAndroidV2
{
    class MyView : View
    {
        const int SIZE = 100;
        int step;
        GenerateArmy army;
        private List<Tuple<Rect, ISquad>> lists = new List<Tuple<Rect, ISquad>>();
        public MyView(Context context) : base(context)
        {

            army = new GenerateArmy();
        }
        
        public override void Draw(Canvas canvas)
        {
            for (int i = 0; i < 5; i++)
            {
                step = Width / SIZE;
                var rectsquad = new RectSquad(5, 2, UnitType.SwordsMan, Team.Blue, 15 * i + 10, 15 * i + 10);
                var isAdded = army.AddSquad(rectsquad);
                if (isAdded)
                {
                    var a = new Rect(rectsquad.MinX * step, rectsquad.MinY * step,
                        rectsquad.MaxX * step, rectsquad.MaxY * step);

                    Paint paint = new Paint
                    {
                        Color=Color.Green
                    };
                    paint.SetStyle(Paint.Style.Fill);
                    canvas.DrawRect(a, paint);
                    lists.Add(new Tuple<Rect, ISquad>(a, rectsquad));
                }
            }
        }
    }
}