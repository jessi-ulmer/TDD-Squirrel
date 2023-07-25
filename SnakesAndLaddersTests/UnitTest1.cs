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

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Move_Should_Return_Something()
        {
            var reset = Move(1, 1);
        }

        public int Move(int position, int movement)
        {
            return 0;
        }
    }
}