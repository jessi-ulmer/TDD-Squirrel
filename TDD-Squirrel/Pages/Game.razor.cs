using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private readonly PieceMover _pieceMover;

        private int _preparationPayingFileSize = 1;

        private int _columnsCount = 4;
        private int _rowsCount = 1;

        private Position _piecePosition = default!;
        private bool _disabledDie;
        private bool _showGame;

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
            _piecePosition = new Position(0, game.Rows - 1);

            StateHasChanged();
        }
    }
}

