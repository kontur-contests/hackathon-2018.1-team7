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

        private readonly IStrategy _horseUp;
        private readonly IStrategy _horseDown;
        private readonly StrategySet _strategiesHorseUp;
        private readonly StrategySet _strategiesHorseDown;

        internal WorldsGenerator(World world)
        {
            var meleeFightStrategy = new MeleeFightStrategy(world);

            _up = new DefaultMoveStrategy(1, 0, world);
            _down = new DefaultMoveStrategy(-1, 0, world);
            
            _strategiesUp = new StrategySet(meleeFightStrategy, _up);
            _strategiesDown = new StrategySet(meleeFightStrategy, _down);

            _horseUp = new HorseMoveStrategy(1, 0, world);
            _horseDown = new HorseMoveStrategy(-1, 0, world);

            _strategiesHorseUp = new StrategySet(meleeFightStrategy, _horseUp);
            _strategiesHorseDown = new StrategySet(meleeFightStrategy, _horseDown);

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
            var strats = team == Team.Blue ? _strategiesUp : _strategiesDown;
            
            var unit = new SwordsMan(team, strats, y, x);
            
            _world.AddUnit(unit);
            return unit;
        }

        public IUnit CreateHorseman(Team team, int y, int x)
        {
            var strats = team == Team.Blue ? _strategiesHorseUp : _strategiesHorseDown;

            var unit = new HorseMan(team, strats, y, x);

            _world.AddUnit(unit);
            return unit;
        }
    }
}
