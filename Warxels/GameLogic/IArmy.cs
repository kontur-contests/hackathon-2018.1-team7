namespace GameLogic
{
    using System.Collections.Generic;

    public interface IArmy
    {
        IEnumerable<IUnit> GetUnits();

        IUnit GetUnit(int y, int x);

        IEnumerable<IUnit> GetNearbyUnits(IUnit unit, int radius);

        void Remove(IUnit unit);
    }
}
