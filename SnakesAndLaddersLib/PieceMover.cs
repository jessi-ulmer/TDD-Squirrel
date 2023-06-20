namespace SnakesAndLaddersLib;

public interface IDiceRoller
{
    int RollDie();
}

public class DiceRoller : IDiceRoller
{
    public  int RollDie()
    {
        var generator = new Random();
        var result = generator.Next(1, 7);
        return result;
    }
}

public class PieceMover
{
    private IDiceRoller _diceRoller;

    public PieceMover(IDiceRoller diceRoller)
    {
        _diceRoller = diceRoller;
    }

    public  MovingResult Move(int previousPosition)
    {
        var dieRoll = _diceRoller.RollDie();
        var newPosition = CalculatePosition(previousPosition, dieRoll);
        var gameFinished = newPosition == 10;
        return new MovingResult(newPosition, gameFinished);
    }

    public static int CalculatePosition(int previousPosition, int dieResult)
    {
        var nextPosition = previousPosition + dieResult;
        return Math.Min(nextPosition, 10);
    }

    public record MovingResult(int Position, bool IsFinalSquareReached);
}
