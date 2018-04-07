namespace GameLogic
{
    using GameLogic.Strategies;

    internal sealed class SwordsMan : UnitBase
    {
        public SwordsMan(Team team, int health, StrategySet strategies)
            : base(team, health, strategies)
        {
        }
    }
}
