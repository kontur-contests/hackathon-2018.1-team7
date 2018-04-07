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

namespace DevUiAndroidV2
{
    class GenerateArmy
    {
        private List<ISquad> _squads = new List<ISquad>();
        public List<ISquad> GetSquads()
        {
            return _squads;
        }

        public bool AddSquad(ISquad squad)
        {
            if (!_squads.Any(val => val.MaxX < squad.MinX || val.MinX > squad.MaxX
                                   || val.MinY > squad.MaxY || val.MaxY < squad.MinY))
            {
                _squads.Add(squad);
                return true; 
            }                           
            return false;
        }

        public bool CheckSquad(ISquad squad)
        {
            return !_squads.Any(val => val.MaxX < squad.MinX || val.MinX > squad.MaxX
                                    || val.MinY > squad.MaxY || val.MaxY < squad.MinY);
        }
    }
}