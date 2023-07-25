using System.Security.Cryptography;
using FluentAssertions;

namespace SnakesAndLaddersTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, 1, 1)]
        [TestCase(1, 3, 4)]
        [TestCase(0,3,3)]
        public void Move_Should_Return_Something(int position, int movement, int expected)
        {
            var reset = Move(position, movement);
            reset.Should().Be(expected);
        }

        public int Move(int position, int movement)
        {
            return position + movement;
        }
    }
}