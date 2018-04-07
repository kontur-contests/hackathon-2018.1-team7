namespace GameLogic
{
    using System.Collections.Generic;

    public interface IArmy
    {
        IEnumerable<IUnit> GetUnits();

        IUnit GetUnit(int y, int x);

        IEnumerable<IUnit> GetNearbyUnits(IUnit unit, int radius);

        IEnumerable<IUnit> GetNearbyUnits(IUnit unit, int dx, int dy);

        IUnit GetFirstUnit(IUnit unit, int dx, int dy, int depth);

        void Remove(IUnit unit);
    }
}
