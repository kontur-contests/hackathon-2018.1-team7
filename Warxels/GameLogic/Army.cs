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
            return _units.Values;
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

            _units.Add(key, unit);
        }

        public void Remove(IUnit unit)
        {
            var key = UnitBase.GetPositionKey(unit.Y, unit.X);

            _units.Remove(key);
        }
    }
}
