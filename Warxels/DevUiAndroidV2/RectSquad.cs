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
using CocosSharp;
using GameLogic;

namespace DevUIAndroid
{
    class RectSquad : ISquad
    {
        private UnitType _type;
        private List<IUnit> _units;
        private int _x;
        private int _y;
        private int _xMin;
        private int _yMin;
        private Team _team;

        public RectSquad(int x, int y, UnitType type, Team team, int xMin, int yMin)
        {
            _units = new List<IUnit>(x * y);
            _x = x;
            _y = y;
            _xMin = xMin;
            _yMin = yMin;
            _type = type;
            _team = team;
        }
        
        public int MinX => _xMin;
        public int MaxX => _xMin+_x;
        public int MinY => _yMin;
        public int MaxY => _yMin+_y;

        public bool CheckAndSetPos(GenerateArmy army, int x, int y)
        {
            var tempX = _xMin;
            var tempY = _yMin;
            _xMin = x;
            _yMin = y;
            var canAdded = army.CheckSquad(this);
            _xMin = canAdded ? _xMin : tempX;
            _yMin = canAdded ? _yMin : tempY;
            return canAdded;
        }
        public IEnumerable<IUnit> GetUnits()
        {
            return null;
        }
    }
}