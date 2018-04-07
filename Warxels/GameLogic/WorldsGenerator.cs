namespace GameLogic
{
    using GameLogic.Strategies;
    
    public class WorldsGenerator
    {
        private readonly World _world;

        private readonly IStrategy _up;
        private readonly IStrategy _down;
        private readonly StrategySet _meleeStrategiesUp;
        private readonly StrategySet _meleeStrategiesDown;

        private readonly IStrategy _horseUp;
        private readonly IStrategy _horseDown;
        private readonly StrategySet _strategiesHorseUp;
        private readonly StrategySet _strategiesHorseDown;

        private readonly StrategySet _archerStrategiesUp;
        private readonly StrategySet _archerStrategiesDown;

        private WorldsGenerator(World world)
        {
            var meleeFightStrategy = new MeleeFightStrategy(world);
            var moveToEnemyStrategy = new MoveToEnemyStrategy(world);
            var fireStrategy = new FireStrategy(world);

            _up = new DefaultMoveStrategy(1, 0, world);
            _down = new DefaultMoveStrategy(-1, 0, world);

            _meleeStrategiesUp = new StrategySet(meleeFightStrategy, _up);
            _meleeStrategiesDown = new StrategySet(meleeFightStrategy, _down);

            _horseUp = new HorseMoveStrategy(1, 0, world);
            _horseDown = new HorseMoveStrategy(-1, 0, world);

            _strategiesHorseUp = new StrategySet(meleeFightStrategy, _horseUp);
            _strategiesHorseDown = new StrategySet(meleeFightStrategy, _horseDown);

            _archerStrategiesUp = new StrategySet(fireStrategy, meleeFightStrategy, _up);
            _archerStrategiesDown = new StrategySet(fireStrategy, meleeFightStrategy, _down);

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
            var strats = team == Team.Blue ? _meleeStrategiesUp : _meleeStrategiesDown;

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

        public IUnit CreateArcher(Team team, int y, int x)
        {
            var strats = team == Team.Blue ? _archerStrategiesUp : _archerStrategiesDown;

            var unit = new Archer(team, strats, y, x);

            _world.AddUnit(unit);
            return unit;
        }
    }
}
