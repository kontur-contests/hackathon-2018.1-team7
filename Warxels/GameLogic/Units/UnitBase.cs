namespace GameLogic
{
    using GameLogic.Strategies;
    using System;
    using System.Runtime.CompilerServices;

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

        public virtual float GetTerrainPenalty(byte terrainId)
        {
            switch (terrainId)
            {
                case 1: return 1.5f;
                default: return 1;
            }
        }

        public int GetHealthPercentage()
        {
            var result = 100 * Health / MaxHealth;
            return result > 0 ? result : 0;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetPositionKey(int y, int x)
        {
            return y * 3733 ^ x;
        }

        public int GetMovementCost(Vector moveVector, byte terrainId)
        {
            var tempMoveCost = MoveCost * GetTerrainPenalty(terrainId);
            var length = moveVector.GetLengthSquared();
            if (length == 0)
            {
                return 0;
            }

            if (length == 1)
            {
                return (int)tempMoveCost;
            }

            if (length == 2)
            {
                return (int)Math.Ceiling(1.4 * tempMoveCost);
            }

            return (int)Math.Ceiling(length * (double)tempMoveCost);
        }
    }
}
