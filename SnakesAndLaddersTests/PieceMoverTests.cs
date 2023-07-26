using System.Security.Cryptography;
using FluentAssertions;
using FakeItEasy;
using SnakesAndLadders;

namespace SnakesAndLaddersTests
{
    public class PieceMoverTests
    {
        private PieceMover _sut; // System Under Test
        private IDiceRoller _diceRoller;
        [SetUp]
        public void Setup()
        {
            _diceRoller = A.Fake<IDiceRoller>();
            _sut = new PieceMover(_diceRoller);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TestCase(0, 1, 1)]
        [TestCase(0, 3, 3)]
        [TestCase(4, 3, 7)]
        [TestCase(14, 3, 17)]
        public void Move_Should_Return_ExpectedField(int position, int movement, int expected)
        {
            var result = _sut.Move(position, movement);
            result.Should().Be(expected);
        }

        [Test]
        public void RollDieAndMove_Should_Return_4()
        {
            A.CallTo(() => _diceRoller.RollDie()).Returns(4);
            var result = _sut.RollDieMove(0);
            result.Should().Be(4);
        }
    }
}