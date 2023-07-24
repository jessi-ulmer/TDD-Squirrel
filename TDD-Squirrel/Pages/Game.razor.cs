using SnakesAndLaddersLib;
using TDD_Squirrel.Models;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private readonly PieceMover _pieceMover;

        private int _preparationPayingFileSize = 1;

        private int _columnsCount = 4;
        private int _rowsCount = 1;
        private Position _startFieldPosition = default!;
        private Position _endFieldPosition = default!;

        private Position _piecePosition = default!;
        private bool _disabledDie;
        private bool _showGame;

        private const int FieldSize = 100;
        private string _svgSize = string.Empty;
        private List<GameActionField> _actionFields = new();

        public Game()
        {
            var diceRoller = new DiceRoller();
            _pieceMover = new PieceMover(diceRoller);
        }

        private void MovePiece()
        {
            var result = _pieceMover.Move(_piecePosition, _rowsCount, _columnsCount);
            _disabledDie = result.IsFinalSquareReached;
            _piecePosition = result.Position;
        }

        private void StartNewGame()
        {
            var game = GameCreator.CreateGame(_preparationPayingFileSize);
            _disabledDie = game.IsDieDisabled;
            _showGame = game.Status;
            _columnsCount = game.Columns;
            _rowsCount = game.Rows;

            // Vorerst selbst, soll aber noch von CreateGame kommen
            _piecePosition = new Position(0, _rowsCount - 1);
            _startFieldPosition = new Position(0, _rowsCount - 1);
            _endFieldPosition = (_rowsCount % 2 == 0) ? new Position(0, 0) : new Position(_rowsCount - 1, 0);

            CreateActionFields();

            StateHasChanged();
        }

        private void CreateActionFields()
        {
            _actionFields = new List<GameActionField>();

            // Testwerte für Leiter & Schlange / Kommt noch nicht von CreateGame
            // Start Dummy
            var ladderStart = new Position(2, _rowsCount - 1);
            var ladderEnd = new Position(2, 0);

            var snakeStart = new Position(1, 0);
            var snakeEnd = new Position(0, _rowsCount - 2);
            // End Dummy

            var size = FieldSize * _columnsCount;
            _svgSize = $"{size}px";

            var ladder = CalculateActionFieldPositions(ladderStart, ladderEnd, GameActionType.Ladder);
            _actionFields.Add(ladder);

            var snake = CalculateActionFieldPositions(snakeStart, snakeEnd, GameActionType.Snake);
            _actionFields.Add(snake);
        }

        private static GameActionField CalculateActionFieldPositions(Position start, Position end, GameActionType type)
        {
            var startX = (start.X * FieldSize) + (FieldSize / 2);
            var startY = (start.Y * FieldSize) + (FieldSize / 2);
            var actionFieldStart = new Position(startX, startY);

            var endX = (end.X * FieldSize) + (FieldSize / 2);
            var endY = (end.Y * FieldSize) + (FieldSize / 2);

            endY = type == GameActionType.Ladder ? endY + 10 : endY - 10;

            var actionFieldEnd = new Position(endX, endY);

            return new GameActionField(actionFieldStart, actionFieldEnd, type);
        }
    }
}

