namespace GameLogic
{
    internal sealed class World : IWorld
    {
        private readonly Army _army;

        public World(int length, int width, Army army)
        {
            _army = army;
            Length = length;
            Width = width;
        }

        public int Length { get; }

        public int Width { get; }

        public IArmy Army => _army;

        public void MoveUnit(UnitBase unit, int y, int x)
        {
            _army.Move(unit, y, x);
        }
    }
}
