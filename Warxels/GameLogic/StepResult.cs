namespace GameLogic
{
    using System.Collections.Generic;

    public sealed class StepResult
    {
        public StepResult(bool wasMoves, IReadOnlyCollection<IUnit> deadUnits)
        {
            WasMoves = wasMoves;
            DeadUnits = deadUnits;
        }

        public bool WasMoves { get; }

        public IReadOnlyCollection<IUnit> DeadUnits { get; }
    }
}
