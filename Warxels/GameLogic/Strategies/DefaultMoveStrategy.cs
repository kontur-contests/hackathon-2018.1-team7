namespace GameLogic.Strategies
{
    internal sealed class DefaultMoveStrategy : IStrategy
    {
        private readonly int _dy;

        private readonly int _dx;

        private readonly World _world;

        public DefaultMoveStrategy(int dy, int dx, World world)
        {
            _dx = dx;
            _dy = dy;
            _world = world;
        }

        public bool Apply(UnitBase unit)
        {
            var x = unit.X + _dx;
            var y = unit.Y + _dy;

            if (x >= _world.Width || x < 0 || y >= _world.Length || y < 0)
            {
                return false;
            }

            if (_world.Army.GetUnit(y, x) != null)
            {
                return false;
            }

            _world.MoveUnit(unit, y, x);

            return true;
        }
    }
}
