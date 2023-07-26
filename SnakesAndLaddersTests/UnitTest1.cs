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
        public void Throw_Die_Return_Int_Range_1_to_6()
        {
            var result = Throw_Die();
            result.Should().BeOfType(typeof(int));
            result.Should().BeInRange(1, 6);
            var results = new List<int>();
            for (int i = 0; i < 100; i++) 
            {
                result = Throw_Die();
                results.Add(result);
            }
            results.Should().Contain(1);
            results.Should().Contain(6);
        }

        public int Move(int position, int movement)
        {
            return position + movement;
        }

        private int Throw_Die()
        {
            var random = new Random();
            var result = random.Next(1, 7);
            return result;
        }
    }
}