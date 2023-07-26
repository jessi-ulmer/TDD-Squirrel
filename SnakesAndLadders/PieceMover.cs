using System.Net.Http.Headers;

namespace SnakesAndLadders
{
    public class PieceMover
    {
        private IDiceRoller _dice_roller;

        public PieceMover(IDiceRoller diceRoller) 
        {
            _dice_roller = diceRoller;
        }

        public int RollDieMove(int position)
        {
            var die = _dice_roller.RollDie();
            var new_position = Move(position, die);
            return new_position;
        }
        public int Move(int position, int movement)
        {
            return position + movement;
        }
    }
}