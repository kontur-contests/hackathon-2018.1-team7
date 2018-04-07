namespace GameLogic
{
    using GameLogic.Strategies;

    internal abstract class UnitBase : IUnit
    {
        private readonly StrategySet _strategies;

        protected UnitBase(Team team, int health, StrategySet strategies, int y, int x)
        {
            Team = team;
            Health = health;
            _strategies = strategies;
            Y = y;
            X = x;
        }

        public int Health { get; private set; }

        public int Y { get; private set; }

        public int X { get; private set; }

        public Team Team { get; }

        public bool IsDead => Health == 0;

        public void ApplyStrategies()
        {
            foreach (var strategy in _strategies)
            {
                if (strategy.Apply(this))
                    return;
            }
        }

        public void Move(int y, int x)
        {
            X = x;
            Y = y;
        }

        public int GetPositionKey()
        {
            return GetPositionKey(Y, X);
        }

        public static int GetPositionKey(int y, int x)
        {
            return y * 3733 ^ x;
        }
    }
}
