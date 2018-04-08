using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Locations;
using Java.IO;

namespace GameLogic.Helper
{
    public static class SaveLoadHelper
    {
        public static void SaveTerrain(this IWorld world, string fname, bool android = false)
        {
            if (android)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                fname = Path.Combine(path, fname);
            }
            var builder = new StringBuilder();
            for (int i = 0; i < world.Width; i++)
            {
                for (int j = 0; j <world.Length; j++)
                {
                    builder.Append(GetTerrainView((TerrainType)world.Terrain[i, j]));
                }

                builder.Append(Environment.NewLine);
            }
            System.IO.File.WriteAllText(fname, builder.ToString(), Encoding.Unicode);
        }

        public static void SaveUnits(this IWorld world, string fname, bool android = false)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < world.Width; i++)
            {
                for (int j = 0; j < world.Length; j++)
                {
                    builder.Append(GetUnitView(world.Army.GetUnit(j, i)));
                }

                builder.Append(Environment.NewLine);
            }
            if (android) {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                fname = Path.Combine(path.ToString(), fname);               
            }

            var str = builder.ToString().Where(c => c != ' ' && c != '\n');
            System.IO.File.WriteAllText(fname, builder.ToString(), Encoding.Unicode);
        }


        private static char GetUnitView(IUnit unit)
        {
            if (unit == null)
                return ' ';
            switch (unit.UnitType)
            {
                case UnitType.Archer: return unit.Team == Team.Blue ? 'a' : 'A';
                case UnitType.SwordsMan: return unit.Team == Team.Blue ? 's' : 'S';
                case UnitType.HorseMan: return unit.Team == Team.Blue ? 'h' : 'H';
                default: throw new ArgumentOutOfRangeException(nameof(unit.UnitType));
            }
        }

        private static char GetTerrainView(TerrainType terrain)
        {
            switch (terrain)
            {
                case TerrainType.Ground: return ' ';
                case TerrainType.Marsh: return 'm';
                default: throw new ArgumentOutOfRangeException(nameof(terrain));
            }
        }

        public static WorldsGenerator LoadTerrainFromFile(string fname, bool android = false)
        {
            if (android)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                fname = Path.Combine(path, fname);
            }

            var lines = System.IO.File.ReadAllLines(fname, Encoding.Unicode);
            
            var width = lines[0].Length;
            var height = lines.Length;

            var WorldGen = WorldsGenerator.GetDefault(height, width);
            var World = WorldGen.GetWorld();

            int x = 0;

            foreach (var line in lines)
            {
                int y = 0;
                if (x >= World.Width)
                    break;

                foreach (var c in line)
                {
                    if (y >= World.Length)
                        break;

                    if (c == 'm')
                        World.Terrain[x, y] = 1;
                    y++;
                }
                x++;
            }

            return WorldGen;
        }


        public static void LoadUnitsFromFile(this WorldsGenerator worldGen, string fname, bool android = false)
        {
            if (android)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                fname = Path.Combine(path, fname);
            }

            var lines = System.IO.File.ReadAllLines(fname,Encoding.Unicode);
            if (lines.Length < 0)
                return;

            var width = lines[0].Length;
            var height = lines.Length;
            var world = worldGen.GetWorld();
            world.Army.Clear();

            int x = 0;

            foreach (var line in lines)
            {
                int y = 0;
                if (x >= world.Width)
                    break;

                foreach (var c in line)
                {
                    if (y >= world.Length)
                        break;
                    
                    switch (c)
                    {
                        case 'a': worldGen.CreateUnit(UnitType.Archer, Team.Blue, y, x); break;
                        case 's': worldGen.CreateUnit(UnitType.SwordsMan, Team.Blue, y, x); break;
                        case 'h': worldGen.CreateUnit(UnitType.HorseMan, Team.Blue, y, x); break;
                        case 'A': worldGen.CreateUnit(UnitType.Archer, Team.Red, y, x); break;
                        case 'S': worldGen.CreateUnit(UnitType.SwordsMan, Team.Red, y, x); break;
                        case 'H': worldGen.CreateUnit(UnitType.HorseMan, Team.Red, y, x); break;
                        case ' ': break;
                        default: throw new InvalidOperationException("Unknown unit type " + c);
                    }
                    y++;
                }
                x++;
            }
        }
    }
}
