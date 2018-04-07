namespace GameLogic
{
    using GameLogic.Strategies;
    using System;

    internal abstract class UnitBase : IUnit
    {
        private readonly StrategySet _strategies;

        protected UnitBase(Team team, StrategySet strategies, int y, int x)
        {
            Team = team;
            _strategies = strategies;
            Y = y;
            X = x;
            Health = MaxHealth;
        }

        public virtual int MaxHealth => 100;
        
        public int Health { get; private set; }

        public int Y { get; private set; }

        public int X { get; private set; }

        public Team Team { get; }

        public bool IsDead => Health <= 0;

        public abstract UnitType UnitType { get; }

        public abstract int DamageValue { get; }

        public abstract int MoveCost { get; }

        public double GetHealthPercentage()
        {
            return Math.Max(0, 100 * Health / MaxHealth);
        }

        public bool ApplyStrategies()
        {
            Power++;

            foreach (var strategy in _strategies)
            {
                var result = strategy.Apply(this);

                switch (result)
                {
                    case StrategyResult.NotEnoughPower:
                        return false;
                    case StrategyResult.Applied:
                    {
                        Power = 0;
                        return true;
                    }
                    case StrategyResult.NotApplicable:
                        continue;
                }
            }

            return false;
        }

        public int Power { get; set; }

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

        public int GetMovementCost(Vector moveVector)
        {
            var length = moveVector.GetLengthSquared();
            if (length == 0)
            {
                return 0;
            }

            if (length == 1)
            {
                return MoveCost;
            }

            if (length == 2)
            {
                return (int)Math.Ceiling(1.4 * MoveCost);
            }

            return (int)Math.Ceiling(length * (double)MoveCost);
        }
    }
}
