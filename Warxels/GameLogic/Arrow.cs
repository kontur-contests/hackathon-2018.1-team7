namespace GameLogic
{
    internal sealed class Arrow : ProjectileBase
    {
        public Arrow(int y, int x, int targetX, int targetY, float dx, float dy)
            : base(y, x, targetX, targetY, dx, dy)
        {

        }

        public override int DamageValue => 10;
    }
}
