namespace SnakesAndLaddersLib
{
    public class GameCreator
    {
        public static Game CreateGame(int i)
        {
            return new Game(false, true, 0 ,10);    
        }
    }
}