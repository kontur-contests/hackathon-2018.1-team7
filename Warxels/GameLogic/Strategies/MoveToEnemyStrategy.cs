namespace GameLogic.Strategies
{
    internal sealed class MoveToEnemyStrategy : IStrategy
    {
        private readonly World _world;
        private int _lookupRadius;

        public MoveToEnemyStrategy(World world, int lookupRadius)
        {
            _world = world;
            _lookupRadius = lookupRadius;
        }

        public StrategyResult Apply(UnitBase unit)
        {
            IUnit nearestEnemyUnit = null;
            var minDistance = int.MaxValue;

            foreach (var testUnit in _world.Army.GetNearbyUnits(unit, _lookupRadius))
            {
                if (testUnit == null || testUnit.Team == unit.Team || testUnit.Health <= 0)
                    continue;

                var distanceSquared = DistanceHelper.GetDistanceSquared(unit, testUnit);

                if (distanceSquared > minDistance)
                {
                    continue;
                }

                // если два врага находятся на одинаковом расстоянии, бежать к тому, у кого ХП меньше.
                if (distanceSquared == minDistance && nearestEnemyUnit != null && nearestEnemyUnit.Health > testUnit.Health)
                {
                    continue;
                }

                minDistance = distanceSquared;
                nearestEnemyUnit = testUnit;
            }

            if (nearestEnemyUnit != null)
            {
                var moveVector = DistanceHelper.GetMoveTowardsPoint(unit, nearestEnemyUnit.X, nearestEnemyUnit.Y);
                var cost = unit.GetMovementCost(moveVector, _world.Terrain[unit.X, unit.Y]);

                if (unit.Power < cost)
                    return StrategyResult.NotEnoughPower;

                var x = unit.X + moveVector.X;
                var y = unit.Y + moveVector.Y;

                if (!_world.IsPointWithin(x, y))
                {
                    return StrategyResult.NotApplicable;
                }

                bool okToMove = false;
                if (_world.Army.GetUnit(y, x) != null)
                {
                    // Так, прямо по курсу какой-то хер, попробуем обойти.

                    foreach(var possibleWay in DistanceHelper.GetAdjancedDirectionVectors(moveVector))
                    {
                        cost = unit.GetMovementCost(possibleWay, _world.Terrain[unit.X, unit.Y]);

                        if (unit.Power < cost)
                            return StrategyResult.NotEnoughPower;

                        x = unit.X + possibleWay.X;
                        y = unit.Y + possibleWay.Y;

                        if (_world.IsPointWithin(x, y) && _world.Army.GetUnit(y, x) == null)
                        {
                            okToMove = true;
                            break;
                        }
                    }
                }
                else
                {
                    okToMove = true;
                }
                
                if(!okToMove)
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
