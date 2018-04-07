namespace GameLogic.Strategies
{
    internal sealed class MeleeFightStrategy : IStrategy
    {
        private readonly int _cost = 15;

        private readonly World _world;

        private readonly int[] _dx = { -1, 0, 1 };
        private readonly int[] _dy = { -1, 0, 1 };

        public MeleeFightStrategy(World world)
        {
            _world = world;
        }

        public StrategyResult Apply(UnitBase unit)
        {
            IUnit minUnit = null;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var y = unit.Y + _dy[i];
                    var x = unit.X + _dx[j];

                    var testUnit = _world.Army.GetUnit(y, x);
                    if (testUnit == null || testUnit.Team == unit.Team || testUnit.Health <= 0)
                        continue;

                    if (minUnit == null || minUnit.Health > testUnit.Health)
                    {
                        minUnit = testUnit;
                    }
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
