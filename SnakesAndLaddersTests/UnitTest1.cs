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
            var result = Move(position, movement);
            result.Should().Be(expected);
        }

        [Test]
        public void Throw_Die_Returns_1_to_6()
        {
            var result = Throw_Die();
            result.Should().BeInRange(1, 6);
        }

        public int Move(int position, int movement)
        {
            return position + movement;
        }

        private int Throw_Die()
        {
            return 0;
        }
    }
}