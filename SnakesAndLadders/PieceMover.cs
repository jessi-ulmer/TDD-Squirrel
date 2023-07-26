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

        public int RollDieMove(int position, int max_fields)
        {
            var die = _dice_roller.RollDie();
            var new_position = Move(position, die);
            if(Check_End_Reached(position, max_fields))
            {
                return max_fields;
            }
            return new_position;
        }
        public int Move(int position, int movement)
        {
            return position + movement;
        }

        public bool Check_End_Reached(int position, int max_fields)
        {
            if(position >= max_fields)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}