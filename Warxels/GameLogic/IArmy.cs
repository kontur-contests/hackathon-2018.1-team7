namespace GameLogic
{
    using System.Collections.Generic;

    public interface IArmy
    {
        IEnumerable<IUnit> GetUnits();

        IUnit GetUnit(int y, int x);

        IEnumerable<IUnit> GetNearbyUnits(IUnit unit, int radius);

        IUnit GetFirstUnit(IUnit unit, int dx, int dy, int depth);

        void Remove(IUnit unit);
    }
}
