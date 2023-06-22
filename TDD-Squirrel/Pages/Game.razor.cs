using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        public int NumberOfFields = 10;

        public int PiecePosition = 0;

        public bool EnabledDie = true;

        private void MovePiece()
        {
            var diceRoller = new DiceRoller();
            var pieceMover = new PieceMover(diceRoller);
            var result =  pieceMover.Move(PiecePosition);
            EnabledDie = result.IsFinalSquareReached is false;
            PiecePosition = result.Position;

        }
    }
}
