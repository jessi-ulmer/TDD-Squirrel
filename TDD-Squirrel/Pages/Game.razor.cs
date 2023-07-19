using Microsoft.AspNetCore.Components;
using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private readonly PieceMover _pieceMover;

        //Muss noch in eine extra Komponente ausgelagert werden
        private int _columnsCountPreparation = 1;
        //ToDo: Rauswerfen - brauchen wir nicht!
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
            var result = _pieceMover.Move(_piecePosition, _rowsCount, _columnsCount);
            _disabledDie = result.IsFinalSquareReached;
            _piecePosition = result.Position;

            Console.WriteLine(result.Position);

            StateHasChanged();
        }
        private void StartNewGame()
        {
            var game = GameCreator.CreateGame(_columnsCountPreparation);
            _disabledDie = game.IsDieDisabled;
            _showGame = game.Status;
            _columnsCount = game.Columns;
            _rowsCount = game.Rows;

            // Vorerst selbst, soll aber noch von CreateGame kommen
            _piecePosition = new Position(0, game.Rows - 1);

            StateHasChanged();
        }

        // Todo: Remove
        private void OnIsPlayingFieldSquareValueChanged(ChangeEventArgs e)
        {
            _isPlayingFieldSquare = (bool)(e.Value ?? false);

            _rowsCount = _isPlayingFieldSquare
                ? 0
                : 1;
        }
    }
}

