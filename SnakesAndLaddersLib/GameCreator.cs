namespace SnakesAndLaddersLib
{
    public class GameCreator
    {
        public static Game CreateGame(int size)
        {
            var numberOfFields = size * size;
            return new Game(false, true, 0 , numberOfFields, size, size);    
        }
    }
}