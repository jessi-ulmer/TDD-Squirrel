namespace SnakesAndLaddersLib;

public record MovingResult(int Position, bool IsFinalSquareReached);

public record Game(bool IsDieDisabled, bool Status, int Position, int NumberOfFields, int Rows, int Columns);