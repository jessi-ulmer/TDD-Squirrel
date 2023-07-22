namespace SnakesAndLaddersLib;

public record Position(int X, int Y);

public record MovingResult(Position Position, int Movement, bool IsFinalSquareReached);

public record Game(bool IsDieDisabled, bool Status, int Rows, int Columns, Ladder[] Ladders);

public record Ladder(Position Start, Position End);