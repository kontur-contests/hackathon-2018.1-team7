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

        public int MaxSizeArmy => 1000;
        public int Size => _squads.Sum(s => s.Size);

        public bool AddSquad(ISquad squad)
        {
            if (CheckSquad(squad))
            {
                _squads.Add(squad);
                return true; 
            }                           
            return false;
        }

        public bool CheckSquad(ISquad squad)
        {
            var inWorldSpace = squad.MinX >= 0 && squad.MaxX < MyView.SIZE 
                               && squad.MinY >= 0 && squad.MaxY < MyView.SIZE/2;
            return inWorldSpace && (_squads.Count == 0 || _squads.All(val => squad==val 
                                    || val.MaxX < squad.MinX || val.MinX > squad.MaxX
                                     || val.MinY > squad.MaxY || val.MaxY < squad.MinY));
        }
    }
}