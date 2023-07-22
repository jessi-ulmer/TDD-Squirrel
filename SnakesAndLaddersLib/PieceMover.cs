namespace SnakesAndLaddersLib;

public class PieceMover
{
    private readonly IDiceRoller _diceRoller;

    public PieceMover(IDiceRoller diceRoller)
    {
        _diceRoller = diceRoller;
    }

    public MovingResult Move(Position previousPosition, int rows, int columns)
    {
        var movement = _diceRoller.RollDie();

        var newPosition = CalculatePosition(previousPosition, movement, rows);
        var gameFinished = IsFinalSquareReached(newPosition, rows);
        return new MovingResult(newPosition, movement, gameFinished);
    }

    private static bool IsFinalSquareReached(Position position, int rows)
    {
        var finalSquare = (rows % 2 == 0) ? new Position(0, 0) : new Position (rows-1, 0);
        var isFinalSquareReached = (finalSquare == position);
        return isFinalSquareReached;
    }

    private static Position CalculatePosition(Position previousPosition, int movement, int rows)
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
            if (newPosition == new Position(0, -1))
            {
                return new Position(0, 0);
            }

            if (newPosition == new Position(rows - 1, -1))
            {
                return new Position(rows -1, 0);
            }
            movement--;
        }
        return newPosition;


    }

    private static Direction DecideDirection(Position position, int rows)
    {
        var isRightMovingRow = (rows - position.Y) % 2 == 1;

        var isMovingUp = (isRightMovingRow && (position.X == rows - 1)) ||
                         (!isRightMovingRow && (position.X == 0));
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


    private static Position MoveLeft(Position previousPosition)
    {
        return new Position(previousPosition.X - 1, previousPosition.Y);
    }

    private static Position MoveUp(Position previousPosition)
    {
        return new Position(previousPosition.X, previousPosition.Y -1);
    }

    private static Position MoveRight(Position previousPosition)
    {
        return new Position(previousPosition.X +1, previousPosition.Y);
    }



    private enum Direction
    {
        None,
        Right,
        Up,
        Left,
    }

}