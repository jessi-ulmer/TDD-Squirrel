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
        var movement = _diceRoller.RollDie();
        
        // ToDO: movement größer als verbleibende Felder!
        var newPosition = CalculatePosition(previousPosition, movement, rows);
        //var gameFinished = newPosition == numberOfFields;
        return new MovingResult(newPosition, false);
    }

    private static (int, int) CalculatePosition((int, int) previousPosition, int movement, int rows)
    {

        var newPosition = previousPosition;
        while (movement > 0)
        {
            var direction = DecideDirection(newPosition, rows);
            newPosition = (direction) switch
            {
                Direction.Right => MoveRight(newPosition),
                Direction.Up => MoveUp(newPosition),
                Direction.Left => MoveLeft(newPosition),
                _ => throw new InvalidOperationException()
            };
            movement--;
        }
        return newPosition;
        
        
    }

    private static Direction DecideDirection((int, int) position, int rows)
    {
        var isRightMovingRow = (rows - position.Item1) % 2 == 1;

        var isMovingUp = (isRightMovingRow && (position.Item2 == rows - 1)) ||
                         (!isRightMovingRow && (position.Item2 == 0));
        Direction direction;
        if (isMovingUp)
        {
            direction = Direction.Up;

        }
        else
        {
            direction = isRightMovingRow ? Direction.Right : Direction.Left;
        }

        return direction;
    }


    private static (int, int) MoveLeft((int, int) previousPosition)
    {
        return (previousPosition.Item1, previousPosition.Item2 - 1);
    }

    private static (int, int) MoveUp((int, int) previousPosition)
    {
        return (previousPosition.Item1 - 1, previousPosition.Item2);
    }

    private static (int, int) MoveRight((int, int) previousPosition)
    {
        return (previousPosition.Item1, previousPosition.Item2 + 1);
    }



    private enum Direction
    {
        None,
        Right,
        Up,
        Left,
    }

}