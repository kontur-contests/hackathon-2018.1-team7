namespace GameLogic
{
    using System.Linq;

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

        public StepResult DoTick()
        {
            var wasMoves = DoMoves();

            var dead = RemoveDead();


            return new StepResult(wasMoves, dead);
        }

        private bool DoMoves()
        {
            var wasMoves = false;

            foreach (var unit in _army.GetUnits())
            {
                wasMoves |= unit.ApplyStrategies();
            }

            return wasMoves;
        }

        private IUnit[] RemoveDead()
        {
            var units = _army.GetUnits().Where(o => o.IsDead).ToArray();
            foreach (var unit in units)
            {
                _army.Remove(unit);
            }

            return units;
        }

        public void MoveUnit(UnitBase unit, int y, int x)
        {
            _army.Move(unit, y, x);
        }

        public void AddUnit(UnitBase unit)
        {
            _army.Add(unit);
        }

        public void ApplyDamage(UnitBase unit, int damageValue)
        {
            unit.ApplyDamage(damageValue);
        }
    }
}
