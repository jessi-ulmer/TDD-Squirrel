using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests
{
    public class PieceMoverTests
    {
        private IDiceRoller _diceRoller;
        private PieceMover _sut;

        [SetUp]
        public void SetUp()
        {
            _diceRoller = A.Fake<IDiceRoller>();
            _sut = new PieceMover(_diceRoller);
        }

        [TestCase(0, 1, 1)]
        [TestCase(5, 2, 7)]
        [TestCase(5, 5, 10)]
        [TestCase(7, 6, 10)]
        public void Move_Should_Return_PositionInRange(int previousPosition, int fakedDie, int expected)
        {
            A.CallTo(() => _diceRoller.RollDie()).Returns(fakedDie);
            using var assertionScope = new AssertionScope();

            var result = _sut.Move(previousPosition);
            result.Position.Should().Be(expected);

        }

        [TestCase(9, true)]
        [TestCase(0, false)]
        public void Move_Should_Return_GameStatus(int position, bool expected)
        {
            A.CallTo(() => _diceRoller.RollDie()).Returns(5);
            var result = _sut.Move(position);
            result.IsFinalSquareReached.Should().Be(expected);
        }

    }
}
