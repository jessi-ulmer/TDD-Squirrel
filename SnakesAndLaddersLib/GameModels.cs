namespace SnakesAndLaddersLib;

public record Position(int X, int Y);

public record Game(bool IsDieDisabled, bool Status, int Position, bool[,] Board);

public record MovingResult(Position Position, bool IsFinalSquareReached);

public record Game(bool IsDieDisabled, bool Status, int Rows, int Columns);