namespace GameLogic
{
    using GameLogic.Strategies;

    internal abstract class UnitBase : IUnit
    {
        private readonly StrategySet _strategies;

        protected UnitBase(Team team, int health, StrategySet strategies)
        {
            Team = team;
            Health = health;
            this._strategies = strategies;
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
    }
}
