using System.Collections.Generic;
using System.Linq;
using GameLogic;

namespace DevUiAndroidV2
{
    class GenerateArmy
    {
        private List<ISquad> _squads = new List<ISquad>();
        public List<ISquad> GetSquads()
        {
            return _squads;
        }

        public int MaxSizeArmy => 640;
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
                               && squad.MinY >= MyView.SIZE / 2 && squad.MaxY < MyView.SIZE;
            return inWorldSpace && (_squads.Count == 0 || _squads.All(val => squad == val
                                    || val.MaxX < squad.MinX || val.MinX > squad.MaxX
                                     || val.MinY > squad.MaxY || val.MaxY < squad.MinY));
        }

        public IWorld GenerateWorld()
        {
            var generator = WorldsGenerator.GetDefault(MyView.SIZE * 3 / 2, MyView.SIZE);
            foreach (var s in _squads)
            {
                for (var x = s.MinX; x < s.MaxX; x++)
                {
                    for (var y = s.MinY; y < s.MaxY; y++)
                    {
                        generator.CreateUnit(s.Type, s.Team, y + MyView.SIZE / 3, x);
                    }
                }
            }

            GenerateEnemies(generator);

            return generator.GetWorld();
        }

        public void GenerateEnemies(WorldsGenerator generator)
        {
            generator.AddUnitSquare(Team.Blue, 8, 8, 8, 8, UnitType.HorseMan, 64);
            generator.AddUnitSquare(Team.Blue, 8, 48, 8, 8, UnitType.HorseMan, 64);

            generator.AddUnitSquare(Team.Blue, 8, 24, 16, 8, UnitType.Archer, 128);

            generator.AddUnitSquare(Team.Blue, 24, 16, 16, 8, UnitType.SwordsMan, 128);
            generator.AddUnitSquare(Team.Blue, 24, 32, 16, 8, UnitType.SwordsMan, 128);
        }
    }
}