namespace GameLogic
{
    public interface IUnit
    {
        int Health { get; }

        int MaxHealth { get; }

        double GetHealthPercentage();

        int Y { get; }

        int X { get; }

        Team Team { get; }

        bool ApplyStrategies();

        bool IsDead { get; }

        UnitType UnitType { get; }

        int DamageValue { get; }

        int MoveCost { get; }
    }
}
