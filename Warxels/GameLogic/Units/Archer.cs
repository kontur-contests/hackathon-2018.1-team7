namespace GameLogic
{
    using GameLogic.Strategies;

    internal sealed class Archer : UnitBase
    {
        public Archer(Team team, StrategySet strategies, int y, int x) 
            : base(team, strategies, y, x)
        {
        }

        public override UnitType UnitType => UnitType.Archer;

        public override int DamageValue => 10;

        public override int MoveCost => 8;

        public override int MaxHealth => 60;
    }
}
