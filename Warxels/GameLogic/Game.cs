namespace GameLogic
{
    public sealed class Game
    {
        public static IWorld GenerateWorld(int length, int width, params IUnit[] units)
        {
            var army = new Army(units);
            return new World(length, width, army);
        }
    }
}
