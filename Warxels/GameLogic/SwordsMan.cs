namespace GameLogic
{
    using GameLogic.Strategies;

    internal sealed class SwordsMan : UnitBase
    {
        public SwordsMan(Team team, int health, StrategySet strategies, int y, int x)
            : base(team, health, strategies, y, x)
        {
        }
    }
}
