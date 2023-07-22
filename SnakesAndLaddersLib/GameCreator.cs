using System;

namespace SnakesAndLaddersLib
{
    public class GameCreator
    {
        public static Game CreateGame(int size)
        {
            var ladders = LaddersCreator.CreateLadders(size);
            return new Game(false, true, size, size, ladders);
        }
    }

    public class LaddersCreator
    {
        public static Ladder[] CreateLadders(int size)
        {
            var firstField = size / 2;
            var random = new Random();
            var ladder = new Ladder(new Position( random.Next(size), random.Next(firstField)),
                new Position(random.Next(size), random.Next(firstField, size)));
            var ladders = new Ladder[] { ladder };

            for (int i = 0; i < Math.Sqrt(size) - 1;)
            {
                var newLadder = new Ladder(new Position(random.Next(size), random.Next(firstField)),
                    new Position(random.Next(size), random.Next(firstField, size)));
                if (ladders.Select(l => l.Start).ToList().Any(s => s.Equals(newLadder.End)) is false)
                {
                    if (ladders.Select(l => l.End).ToList().Any(s => s.Equals(newLadder.Start)) is false)
                    {
                        ladders = ladders.Append(newLadder).ToArray();
                        i = ladders.Length;
                    }
                }
                
            }

            return ladders;
        }
    }
}