namespace GameLogic.Strategies
{
    internal sealed class MoveToEnemyStrategy : IStrategy
    {
        private readonly World _world;
        private const int LookupRadius = 5;

        public MoveToEnemyStrategy(World world)
        {
            _world = world;
        }

        public StrategyResult Apply(UnitBase unit)
        {
            IUnit nearestEnemyUnit = null;
            double minDistance = double.PositiveInfinity;

            foreach (var testUnit in _world.Army.GetNearbyUnits(unit, LookupRadius))
            {
                if (testUnit == null || testUnit.Team == unit.Team || testUnit.Health <= 0)
                    continue;

                var distanceSquared = DistanceHelper.GetDistanceSquared(unit, testUnit);

                // если два врага находятся на одинаковом расстоянии, бежать к тому, у кого ХП меньше.
                if (distanceSquared >= minDistance || (nearestEnemyUnit != null && nearestEnemyUnit.Health >= testUnit.Health))
                {
                    break;
                }

                minDistance = distanceSquared;
                nearestEnemyUnit = testUnit;
            }

            if (nearestEnemyUnit != null)
            {
                var moveVector = DistanceHelper.GetMoveTowardsPoint(unit, nearestEnemyUnit.X, nearestEnemyUnit.Y);
                var cost = unit.GetMovementCost(moveVector);

                if (unit.Power < cost)
                    return StrategyResult.NotEnoughPower;

                var x = unit.X + moveVector.X;
                var y = unit.Y + moveVector.Y;

                if (!_world.IsPointWithin(x, y))
                {
                    return StrategyResult.NotApplicable;
                }

                if (_world.Army.GetUnit(y, x) != null)
                {
                    return StrategyResult.NotApplicable;
                }

                _world.MoveUnit(unit, y, x);

                return StrategyResult.Applied;
            }

            return StrategyResult.NotApplicable;
        }
    }
}
