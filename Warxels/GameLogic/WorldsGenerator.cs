using System;

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

        
        private IUnit CreateSwordsman(Team team, int y, int x)
        {
            var strats = team == Team.Blue ? _strategiesUp : _strategiesDown;
            
            var unit = new SwordsMan(team, strats, y, x);
            
            _world.AddUnit(unit);
            return unit;
        }

        private IUnit CreateHorseman(Team team, int y, int x)
        {
            var strats = team == Team.Blue ? _strategiesHorseUp : _strategiesHorseDown;

            var unit = new HorseMan(team, strats, y, x);

            _world.AddUnit(unit);
            return unit;
        }

        public void CreatePreset()
        {
            
        }

        public void AddUnitSquare(Team team, int y, int x, int width, int height, UnitType type, int amount)
        {
            var density = (float)Math.Sqrt(width * height / amount);
            int k = 0;
            for (float i = 0; i < height; i += density)
                for (float j = 0; j < width; j += density)
                {
                    CreateUnit(type, team, (int)(y+i), (int)(x+j));
                    k++;

                    if (k == amount)
                        return;
                }
        }

        public IUnit CreateUnit(UnitType type, Team team, int y, int x)
        {
            switch (type)
            {
                case UnitType.HorseMan:
                    return CreateHorseman(team, y, x);
                case UnitType.SwordsMan:
                    return CreateSwordsman(team, y, x);
            }

            throw new ArgumentOutOfRangeException(nameof(type));
        }
    }
}
