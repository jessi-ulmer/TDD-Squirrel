namespace SnakesAndLaddersLib;

public record MovingResult((int, int) Position, bool IsFinalSquareReached);

public record Game(bool IsDieDisabled, bool Status, int Rows, int Columns);