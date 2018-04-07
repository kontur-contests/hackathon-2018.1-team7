namespace GameLogic
{
    using GameLogic.Strategies;
    internal sealed class HorseMan : UnitBase
    {

        public HorseMan(Team team, StrategySet strategies, int y, int x) : base(team, strategies, y, x)
        {
        }

        public override UnitType UnitType => UnitType.HorseMan;

        public override int DamageValue => 50;

        public override int MoveCost => 5;

        public override float GetTerrainPenalty(byte terrainId)
        {
            if (terrainId == 1)
                return 2.5f;

            return base.GetTerrainPenalty(terrainId);
        }
    }
}
