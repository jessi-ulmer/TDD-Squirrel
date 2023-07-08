namespace SnakesAndLaddersLib
{
    public class GameCreator
    {
        public static Game CreateGame()
        {
            return new Game(default, default, default, default);    
        }
    }

    public record Game(bool DisabledDie, bool Status, int Position, int NumberOfFields);
}