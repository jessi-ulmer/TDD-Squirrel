using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        public int NumberOfFields = 10;

        public int PiecePosition = 0;

        private void MovePiece()
        {
            var diceRoller = new DiceRoller();
            var pieceMover = new PieceMover(diceRoller);
            PiecePosition = pieceMover.Move(PiecePosition).Position;
        }
    }
}
