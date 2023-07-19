using Microsoft.AspNetCore.Components;
using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private readonly PieceMover _pieceMover;

        //Muss noch in eine extra Komponente ausgelagert werden
        private int _columnsCountPreparation = 1;
        private int _rowsCountPreparation = 1;

        private int _columnsCount = 4;
        private int _rowsCount = 1;
        private bool _isPlayingFieldSquare;

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
            var result = _pieceMover.Move(_piecePosition, _rowsCountPreparation, _columnsCountPreparation);
            _disabledDie = result.IsFinalSquareReached;
            _piecePosition = result.Position;
        }
        private void StartNewGame()
        {
            var game = GameCreator.CreateGame(_columnsCount);
            _disabledDie = game.IsDieDisabled;
            _showGame = game.Status;
            _columnsCount = game.Columns;
            _rowsCount = game.Rows;

            // Vorerst selbst, soll aber noch von CreateGame kommen
            _piecePosition = new Position(0, game.Columns - 1);

            StateHasChanged();
        }

        private void OnIsPlayingFieldSquareValueChanged(ChangeEventArgs e)
        {
            _isPlayingFieldSquare = (bool)(e.Value ?? false);

            _rowsCount = _isPlayingFieldSquare
                ? 0
                : 1;
        }
    }
}

