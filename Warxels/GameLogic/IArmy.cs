namespace GameLogic
{
    using System.Collections.Generic;

    public interface IArmy
    {
        IEnumerable<IUnit> GetUnits();

        IUnit GetUnit(int y, int x);

        void Remove(IUnit unit);
    }
}
