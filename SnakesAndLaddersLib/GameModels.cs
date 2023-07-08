namespace SnakesAndLaddersLib;

public record MovingResult(int Position, bool IsFinalSquareReached);

public record Game(bool DisabledDie, bool Status, int Position, int NumberOfFields);