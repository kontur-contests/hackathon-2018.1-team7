namespace GameLogic.Strategies
{
    using System;
    using System.Linq;

    internal sealed class FireStrategy : IStrategy
    {
        private readonly int _cost = 30;

        private readonly World _world;

        private int _minDist = 3;

        public FireStrategy(World world)
        {
            _world = world;
        }

        public StrategyResult Apply(UnitBase unit)
        {
            if (_world.Army.GetNearbyUnits(unit, 1).FirstOrDefault(o => o.Team != unit.Team) != null)
            {
                return StrategyResult.NotApplicable;
            }

            var enemy = _world.Army.GetNearbyUnits(unit, 10, 20).Where(o => o.Team != unit.Team)
                .Select(o => new { Unit = o, Dist = DistanceHelper.GetDistanceSquared(unit, o) })
                .Where(o => o.Dist >= _minDist * _minDist)
                .OrderBy(o => o.Dist)
                .Select(o => o.Unit)
                .FirstOrDefault();

            if (enemy != null)
            {
                if (unit.Power < _cost)
                {
                    return StrategyResult.NotEnoughPower;
                }

                float dx = enemy.X - unit.X;
                float dy = enemy.Y - unit.Y;

                var d = (float)Math.Sqrt(dx * dx + dy * dy);
                dx /= d;
                dy /= d;

                var arrow = new Arrow(unit.Y, unit.X, enemy.X, enemy.Y, dx, dy);

                _world.AddProjectile(arrow);

                return StrategyResult.Applied;
            }

            return StrategyResult.NotApplicable;
        }
    }
}
