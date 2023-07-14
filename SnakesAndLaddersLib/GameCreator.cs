namespace SnakesAndLaddersLib
{
    public class GameCreator
    {
        public static Game CreateGame(int size)
        {
            return new Game(false, true, 1, 1);    
        }
    }
}