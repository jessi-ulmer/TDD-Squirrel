namespace SnakesAndLaddersLib;

public class DiceRoller : IDiceRoller
{
    public  int RollDie()
    {
        var generator = new Random();
        var result = generator.Next(1, 7);
        return result;
    }
}