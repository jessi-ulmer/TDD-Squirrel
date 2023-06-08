namespace TDD_Squirrel;

    public class PieceMover
{
    public static MovingResult Move(int previousPosition)
    {
        var dieRoll = RollDie();
        var newPosition = CalculatePosition(previousPosition, dieRoll);
        return new MovingResult(newPosition, true);
    }

    public static int RollDie()
    {
        var generator = new Random();
        var result = generator.Next(1, 7);
        return result;
    }
    public static int CalculatePosition(int previousPosition, int dieResult)
    {
        var nextPosition = previousPosition + dieResult;
        return Math.Min(nextPosition, 10);
    }

    public record MovingResult(int Position, bool FinalSquareReached) { }
}
