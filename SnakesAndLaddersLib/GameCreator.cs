namespace SnakesAndLaddersLib
{
    public class GameCreator
    {
        public static Game CreateGame(int numberOfFields)
        {
            return new Game(false, true, 0 , default!);    
        }
    }
}