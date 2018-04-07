namespace GameLogic
{
    using System;

    internal abstract class ProjectileBase : IProjectile
    {
        private static int _idGenerator = 0;

        public float Y { get; private set; }

        public float X { get; private set; }

        public abstract int DamageValue { get; }

        public int TargetY { get; }

        public int TargetX { get; }

        private readonly float _dx;

        private readonly float _dy;

        private readonly int _id;

        public ProjectileBase(int y, int x, int targetX, int targetY, float dx, float dy)
        {
            Y = y;
            X = x;
            TargetX = targetX;
            TargetY = targetY;
            _dx = dx;
            _dy = dy;
            _id = ++_idGenerator;
        }

        public void Move()
        {
            X += _dx;
            Y += _dy;
        }

        public bool Finished => Math.Abs(X - TargetX) <= 0.5 && Math.Abs(Y - TargetY) <= 0.5;

        public override bool Equals(object obj)
        {
            return Equals(obj as ProjectileBase);
        }

        private bool Equals(ProjectileBase other)
        {
            return _id == other._id;
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}
