namespace GameLogic
{
    using GameLogic.Strategies;

    public class WorldsGenerator
    {
        private readonly World _world;

        private readonly IStrategy _up;
        private readonly IStrategy _down;
        private readonly StrategySet _strategiesUp;
        private readonly StrategySet _strategiesDown;

        internal WorldsGenerator(World world)
        {
            _up = new DefaultMoveStrategy(1, 0, world);
            _down = new DefaultMoveStrategy(-1, 0, world);

            _strategiesUp = new StrategySet(_up);
            _strategiesDown = new StrategySet(_down);

            _world = world;
        }

        public IWorld GetWorld()
        {
            return _world;
        }

        public static WorldsGenerator GetDefault(int length, int width)
        {
            var world = Game.GenerateWorld(length, width);

            return new WorldsGenerator(world);
        }

        public IUnit CreateSwordsman(Team team, int y, int x)
        {
            UnitBase unit;

            if (team == Team.Blue)
            {
                unit = new SwordsMan(team, 100, _strategiesUp, y, x);
            }
            else
            {
                unit = new SwordsMan(team, 100, _strategiesDown, y, x);
            }

            _world.AddUnit(unit);
            return unit;
        }
    }
}
