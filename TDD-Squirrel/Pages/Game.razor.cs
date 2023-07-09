using SnakesAndLaddersLib;

namespace TDD_Squirrel.Pages
{
    public partial class Game
    {
        private PieceMover pieceMover;

        private int NumberOfFields = 10;
        private int NumberOfRows = 3;

        private List<List<bool>> playingFields;
        private List<int> test;

        private int PiecePosition = 1;
        private bool DisabledDie = false;

        public Game()
        {
            var diceRoller = new DiceRoller();
            pieceMover = new PieceMover(diceRoller);
            playingFields = new List<List<bool>>();
            test = new List<int>();
        }

        private void CreateGame()
        {
            playingFields = new List<List<bool>>().ToList();
            for (var index = 0; index < NumberOfRows; index++)
            {
                Console.WriteLine(index);

                var fields = new bool[NumberOfFields];
                playingFields.Add(new List<bool> { false });

                test.Add(index);
            }

            Console.WriteLine("####");
            Console.WriteLine(playingFields);
            StateHasChanged();
        }

        private void MovePiece()
        {
            var result = pieceMover.Move(PiecePosition);
            DisabledDie = result.IsFinalSquareReached;
            PiecePosition = result.Position;
        }
    }
}

