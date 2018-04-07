namespace GameLogic
{
    using System.Collections.Generic;

    public interface IWorld
    {
        int Length { get; }

        int Width { get; }

        IArmy Army { get; }

        StepResult DoTick();

        IEnumerable<IProjectile> GetProjectiles();
    }
}
