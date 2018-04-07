namespace GameLogic
{
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class World : IWorld
    {
        private readonly Army _army;
        public byte[,] Terrain { get; }

        public World(int length, int width, Army army)
        {
            _army = army;
            Length = length;
            Width = width;
            _projectiles = new HashSet<ProjectileBase>();
            Terrain = new byte[width, length];
        }

        public int Length { get; }

        public int Width { get; }

        public bool IsPointWithin(int x, int y)
        {
            return x < Width && x >= 0 && y < Length && y >= 0;
        }

        public IArmy Army => _army;

        public StepResult DoTick()
        {
            MoveProjectiles();

            var wasMoves = DoMoves();

            var dead = RemoveDead();

            return new StepResult(wasMoves, dead);
        }

        private void MoveProjectiles()
        {
            foreach (var projectile in _projectiles)
            {
                projectile.Move();

                if (projectile.Finished)
                {
                    var unit = _army.GetUnit(projectile.TargetY, projectile.TargetX) as UnitBase;
                    if (unit != null)
                    {
                        unit.ApplyDamage(projectile.DamageValue);
                    }
                }
            }

            _projectiles.RemoveWhere(o => o.Finished);
        }

        public IEnumerable<IProjectile> GetProjectiles() => _projectiles;

        private readonly HashSet<ProjectileBase> _projectiles;

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

        public void AddProjectile(Arrow arrow)
        {
            _projectiles.Add(arrow);
        }

        public void SetTerrain(int y, int x, int y1, int x1, byte terrainType)
        {
            if (x < 0)
                x = 0;

            if (y < 0)
                y = 0;

            for (int i = x; i < x1 && i < Width; i++)
                for (int j = y; j < y1 && j < Length; j++)
                    Terrain[i, j] = terrainType;
        }

        
    }
}
