namespace SnakesAndLadders;

public class DiceRoller : IDiceRoller
{
    private Random _random;

    public DiceRoller()
    {
        _random = new Random();
    }

    public int RollDie()
    {
        var result = _random.Next(1, 7);
        return result;
    }
}