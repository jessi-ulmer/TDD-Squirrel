using System.Runtime.InteropServices.JavaScript;
using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private PieceMover pieceMover;
        public Game()
        {
            var diceRoller = new DiceRoller();
            pieceMover = new PieceMover(diceRoller);
        }
        public int NumberOfFields = 10;

        public int PiecePosition = 0;

        public bool DisabledDie = false;
        public bool ShowGame = false;

        private void MovePiece()
        {
            var result =  pieceMover.Move(PiecePosition, NumberOfFields);
            DisabledDie = result.IsFinalSquareReached;
            PiecePosition = result.Position;
        }

        private void StartNewGame()
        {
            var game = GameCreator.CreateGame(15);
            DisabledDie = game.IsDieDisabled;
            ShowGame = game.Status;
            PiecePosition = game.Position;
            NumberOfFields = game.NumberOfFields;
        }
    }
}

