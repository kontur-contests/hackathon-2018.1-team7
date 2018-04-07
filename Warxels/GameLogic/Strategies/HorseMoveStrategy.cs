namespace GameLogic.Strategies
{
    internal sealed class HorseMoveStrategy : DefaultMoveStrategy
    {
        public HorseMoveStrategy(int dy, int dx, World world):base(dy, dx, world)
        {
            Cost = 1;
        }
    }
}
