using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GameLogic;

namespace DevUiAndroidV2
{
    interface ISquad
    {
        int MinX { get; }
        int MaxX { get; }
        int MinY { get; }
        int MaxY { get; }
        bool CheckAndSetPos(GenerateArmy army, int x, int y);
        IEnumerable<IUnit> GetUnits();

    }
}