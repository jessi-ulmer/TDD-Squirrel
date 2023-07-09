using System.Reflection.Metadata.Ecma335;

namespace SnakesAndLaddersLib
{
    public class GameCreator
    {
        public static Game CreateGame(int size)
        {
            var board = new bool[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    board[i, j] = false;
                }
            }

            return new Game(false, true, 0 , board);    
        }
    }
}