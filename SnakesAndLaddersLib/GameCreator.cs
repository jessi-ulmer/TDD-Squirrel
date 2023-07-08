namespace SnakesAndLaddersLib
{
    public class GameCreator
    {
        public static Game CreateGame()
        {
            return new Game(false, true, 0 ,10);    
        }
    }
}