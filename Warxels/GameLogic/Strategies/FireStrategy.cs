namespace GameLogic.Strategies
{
    using System;
    using System.Linq;

    internal sealed class FireStrategy : IStrategy
    {
        private readonly int _cost = 20;

        private readonly World _world;

        public FireStrategy(World world)
        {
            _world = world;
        }

        public StrategyResult Apply(UnitBase unit)
        {
            var enemy = _world.Army.GetNearbyUnits(unit, 20).Where(o => o.Team != unit.Team)
                .OrderBy(o => DistanceHelper.GetDistanceSquared(unit, o)).FirstOrDefault();

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
