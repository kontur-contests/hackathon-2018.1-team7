namespace GameLogic.Strategies
{
    internal class DefaultMoveStrategy : IStrategy
    {        
        protected readonly int _dy;

        protected readonly int _dx;

        protected readonly World World;

        public DefaultMoveStrategy(int dy, int dx, World world)
        {
            _dx = dx;
            _dy = dy;
            World = world;
        }
    
        public virtual StrategyResult Apply(UnitBase unit)
        {
            if (unit.Power < unit.MoveCost*unit.GetTerrainPenalty(World.Terrain[unit.X,unit.Y]))
                return StrategyResult.NotEnoughPower;

            var x = unit.X + _dx;
            var y = unit.Y + _dy;

            if (x >= World.Width || x < 0 || y >= World.Length || y < 0)
            {
                return StrategyResult.NotApplicable;
            }

            if (World.Army.GetUnit(y, x) != null)
            {
                return StrategyResult.NotApplicable;
            }

            World.MoveUnit(unit, y, x);

            return StrategyResult.Applied;
        }
    }
}
