using Microsoft.AspNetCore.Components;
using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private PieceMover pieceMover;

        private int NumberOfFields = 4;
        private int NumberOfRows = 1;
        private bool _isPlayingFieldSquare;

        private int PiecePosition = 1;
        private bool DisabledDie;
        private bool ShowGame;

        public Game()
        {
            var diceRoller = new DiceRoller();
            pieceMover = new PieceMover(diceRoller);
        }

        private void MovePiece()
        {
            var result = pieceMover.Move(PiecePosition, NumberOfFields);
            DisabledDie = result.IsFinalSquareReached;
            PiecePosition = result.Position;
        }
        private void StartNewGame()
        {
            var game = GameCreator.CreateGame(NumberOfFields);
            DisabledDie = game.IsDieDisabled;
            ShowGame = game.Status;
            PiecePosition = game.Position;
            NumberOfFields = game.NumberOfFields;

            StateHasChanged();
        }

        private void OnIsPlayingFieldSquareValueChanged(ChangeEventArgs e)
        {
            _isPlayingFieldSquare = !_isPlayingFieldSquare;

            NumberOfRows = _isPlayingFieldSquare
                ? 0
                : 1;
        }
    }
}

