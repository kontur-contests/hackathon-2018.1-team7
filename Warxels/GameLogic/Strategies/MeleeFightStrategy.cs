namespace GameLogic.Strategies
{
    internal sealed class MeleeFightStrategy : IStrategy
    {
        private readonly int _cost = 15;

        private readonly World _world;

        public MeleeFightStrategy(World world)
        {
            _world = world;
        }

        public StrategyResult Apply(UnitBase unit)
        {
            IUnit minUnit = null;

            foreach(var testUnit in _world.Army.GetNearbyUnits(unit, 1))
            {
                if (testUnit == null || testUnit.Team == unit.Team || testUnit.IsDead)
                    continue;

                if (minUnit == null || minUnit.Health > testUnit.Health)
                {
                    minUnit = testUnit;
                }
            }

            if (minUnit != null)
            {
                if (unit.Power < _cost)
                    return StrategyResult.NotEnoughPower;

                _world.ApplyDamage(minUnit as UnitBase, unit.DamageValue);
                return StrategyResult.Applied;
            }

            return StrategyResult.NotApplicable;
        }
    }
}
