namespace GameLogic
{
    public struct Vector
    {
        public Vector(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public int GetLengthSquared()
        {
            return X * X + Y * Y;
        }
    }
}
