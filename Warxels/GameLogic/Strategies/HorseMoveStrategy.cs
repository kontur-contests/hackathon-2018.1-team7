namespace GameLogic.Strategies
{
    internal sealed class HorseMoveStrategy : DefaultMoveStrategy
    {
        public HorseMoveStrategy(int dy, int dx, World world):base(dy, dx, world)
        {
        }

        public override StrategyResult Apply(UnitBase unit)
        {
            if (unit.Power < unit.MoveCost)
                return StrategyResult.NotEnoughPower;

            var x = unit.X + _dx;
            var y = unit.Y + _dy;

            var blockingUnit = World.Army.GetFirstUnit(unit, _dx, _dy, 5);

            if (blockingUnit != null
                && blockingUnit.Team == unit.Team)
            {
                if ((blockingUnit as UnitBase).MoveCost > unit.MoveCost)
                    if ((x + y) % 2 == 0)
                        x += 1;
                    else
                        x -= 1;
            }
            
            if (!World.IsPointWithin(x, y))
            {
                return StrategyResult.NotApplicable;
            }

            if (World.Army.GetUnit(y, x) != null)
            {
                return StrategyResult.NotApplicable;
            }

            World.MoveUnit(unit, y, x);

            return StrategyResult.Applied;
        }
    }
}
