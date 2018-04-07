namespace GameLogic
{
    public interface IWorld
    {
        int Length { get; }

        int Width { get; }

        IArmy Army { get; }
    }
}
