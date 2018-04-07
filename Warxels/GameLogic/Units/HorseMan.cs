namespace GameLogic
{
    using GameLogic.Strategies;
    internal sealed class HorseMan : UnitBase
    {

        public HorseMan(Team team, StrategySet strategies, int y, int x) : base(team, strategies, y, x)
        {
        }

        public override UnitType UnitType => UnitType.HorseMan;

        public override int DamageValue => 50;
    }
}
