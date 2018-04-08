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
    sealed class MyView : View
    {
        public const int SIZE = 50;
        int step;
        public GenerateArmy Army { get; private set; }
        private Paint paint;
        private Paint focusPaint;
        private Paint borderPaint;
        private Tuple<Rect, ISquad> focus = null;
        private List<Tuple<Rect, ISquad>> lists = new List<Tuple<Rect, ISquad>>();
        public MyView(Context context) : base(context)
        {
            SetPadding(0, 0, 0, 0);
            paint = new Paint
            {
                Color = Color.Red
            };
            paint.SetStyle(Paint.Style.Fill);
            borderPaint = new Paint(paint) {Color = Color.Cyan};
            focusPaint = new Paint(paint) {Color = Color.Gray};
            Army = new GenerateArmy();
        }
        
        public override void Draw(Canvas canvas)
        {
            canvas.DrawLine(0, Bottom / 2, Right, Bottom / 2, borderPaint);
            foreach(var t in lists)
            {
                canvas.DrawRect(t.Item1, Equals(t, focus) ? focusPaint : paint);
            }
        }

        public void TapTap(float x, float y, int rows, int ranks, UnitType type)
        {
            step = Width / SIZE;
            var location = new Point((int)x, (int)y);
            if (focus == null)
            {
                focus = lists.FirstOrDefault(val => location.X < val.Item2.MaxX * step && location.X > val.Item2.MinX * step
                                               && location.Y < val.Item2.MaxY * step && location.Y > val.Item2.MinY * step);
                if (focus == null && rows != 0 && ranks!=0)
                {

                    var rectsquad = new RectSquad(rows, ranks, type, Team.Red, location.X/step, location.Y/step);
                    var isAdded = Army.AddSquad(rectsquad);
                    if (isAdded)
                    {
                        var a = new Rect(rectsquad.MinX * step, rectsquad.MinY * step,
                            rectsquad.MaxX * step, rectsquad.MaxY * step);

                        lists.Add(new Tuple<Rect, ISquad>(a, rectsquad));
                    }
                }
            }
            else
            {
                if(focus.Item2.CheckAndSetPos(Army, (int)(location.X / step), (int)(location.Y / step)))
                {
                    var rectsquad = focus.Item2;
                    focus.Item1.Set(new Rect(rectsquad.MinX * step, rectsquad.MinY * step,
                        rectsquad.MaxX * step, rectsquad.MaxY * step));
                }
                focus = null;
            }
            Invalidate();
        }
    }
}