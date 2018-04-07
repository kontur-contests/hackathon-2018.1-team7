namespace GameLogic
{
    public interface IProjectile
    {
        float Y { get; }

        float X { get; }

        int DamageValue { get; }
    }
}
