namespace GameLogic
{
    internal sealed class Game
    {
        public static World GenerateWorld(int length, int width, params IUnit[] units)
        {
            var army = new Army(units);
            return new World(length, width, army);
        }
    }
}
