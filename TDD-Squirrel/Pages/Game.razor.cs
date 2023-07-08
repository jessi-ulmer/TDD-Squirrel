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
        private int NumberOfRows = 3;

        public int PiecePosition = 1;

        public bool DisabledDie = false;

        private void MovePiece()
        {

            var result = pieceMover.Move(PiecePosition);
            DisabledDie = result.IsFinalSquareReached;
            PiecePosition = result.Position;

        }
    }
}

