namespace SnakesAndLaddersLib;

public class PieceMover
{
    private readonly IDiceRoller _diceRoller;

    public PieceMover(IDiceRoller diceRoller)
    {
        _diceRoller = diceRoller;
    }

    public  MovingResult Move((int, int) previousPosition, int rows, int columns)
    {
        var dieRoll = _diceRoller.RollDie();
        var newPosition = ((int)default!, (int)default!); //CalculatePosition(previousPosition, dieRoll, numberOfFields);
        //var gameFinished = newPosition == numberOfFields;
        return new MovingResult(newPosition, false);
    }

    private static (int, int) CalculatePosition((int, int) previousPosition, int dieResult, int numberOfFields)
    {
        //var nextPosition = previousPosition + dieResult;
        //return Math.Min(nextPosition, numberOfFields);
        return (0, 1);
    }

}