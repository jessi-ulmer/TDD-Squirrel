namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        public int NumberOfFields = 10;

        public int PiecePosition = 0;

        private void MovePiece()
        {
            PiecePosition = PieceMover.Move(PiecePosition).Position;
        }
    }
}
