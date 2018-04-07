namespace GameLogic
{
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class Army : IArmy
    {
        private readonly Dictionary<int, IUnit> _units;

        public Army(params IUnit[] units)
        {
            _units = units.ToDictionary(o => UnitBase.GetPositionKey(o.Y, o.X));
        }

        public IEnumerable<IUnit> GetUnits()
        {
            return _units.Values.ToArray();
        }

        public IUnit GetUnit(int y, int x)
        {
            var key = UnitBase.GetPositionKey(y, x);

            if (_units.TryGetValue(key, out var unit))
            {
                return unit;
            }

            return null;
        }

        public IEnumerable<IUnit> GetNearbyUnits(IUnit unit, int radius)
        {
            for (var x = unit.X - radius; x <= unit.X + radius; x++)
            {
                for (var y = unit.Y - radius; y <= unit.Y + radius; y++)
                {
                    var testUnit = GetUnit(y, x);
                    if (testUnit != null)
                        yield return testUnit;
                }
            }
        }

        public IEnumerable<IUnit> GetNearbyUnits(IUnit unit, int dx, int dy)
        {
            for (var x = unit.X - dx; x <= unit.X + dx; x++)
            {
                for (var y = unit.Y - dy; y <= unit.Y + dy; y++)
                {
                    var testUnit = GetUnit(y, x);
                    if (testUnit != null)
                        yield return testUnit;
                }
            }
        }

        public void Move(UnitBase unit, int y, int x)
        {
            var key = unit.GetPositionKey();

            _units.Remove(key);

            unit.Move(y, x);

            key = unit.GetPositionKey();

            _units[key] = unit;
        }

        public void Add(UnitBase unit)
        {
            var key = unit.GetPositionKey();

            if (_units.ContainsKey(key))
                return;

            _units.Add(key, unit);
        }

        public void Remove(IUnit unit)
        {
            var key = UnitBase.GetPositionKey(unit.Y, unit.X);

            _units.Remove(key);
        }

        public IUnit GetFirstUnit(IUnit unit, int dx, int dy, int depth)
        {
            int posx = unit.X;
            int posy = unit.Y;

            for (int i = 0; i < depth; i++)
            {
                posx += dx;
                posy += dy;

                var foundUnit = GetUnit(posy, posx);

                if (foundUnit != null)
                    return foundUnit;

            }
            return null;
        }
    }
}
