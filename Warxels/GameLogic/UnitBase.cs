namespace GameLogic
{
    using GameLogic.Strategies;

    internal abstract class UnitBase : IUnit
    {
        private readonly StrategySet _strategies;

        protected UnitBase(Team team, StrategySet strategies, int y, int x)
        {
            Team = team;
            _strategies = strategies;
            Y = y;
            X = x;
        }

        public int Health { get; private set; } = 100;

        public int Y { get; private set; }

        public int X { get; private set; }

        public Team Team { get; }

        public bool IsDead => Health <= 0;

        public abstract UnitType UnitType { get; }

        public abstract int DamageValue { get; }

        public bool ApplyStrategies()
        {
            Counter++;

            foreach (var strategy in _strategies)
            {
                if (strategy.Apply(this))
                {
                    Counter = 0;
                    return true;
                }
            }

            return false;
        }

        public int Counter { get; set; }

        public void Move(int y, int x)
        {
            X = x;
            Y = y;
        }

        public void ApplyDamage(int damageValue)
        {
            Health -= damageValue;
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
