namespace GameLogic.Strategies
{
    internal sealed class DefaultMoveStrategy : IStrategy
    {
        private readonly int _cost = 10;

        private readonly int _dy;

        private readonly int _dx;

        private readonly World _world;

        public DefaultMoveStrategy(int dy, int dx, World world)
        {
            _dx = dx;
            _dy = dy;
            _world = world;
        }

        public StrategyResult Apply(UnitBase unit)
        {
            if (unit.Power < _cost)
                return StrategyResult.NotEnoughPower;

            var x = unit.X + _dx;
            var y = unit.Y + _dy;

            if (x >= _world.Width || x < 0 || y >= _world.Length || y < 0)
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
    }
}
