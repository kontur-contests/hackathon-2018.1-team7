namespace GameLogic.Strategies
{
    internal interface IStrategy
    {
        StrategyResult Apply(UnitBase unit);
    }
}
