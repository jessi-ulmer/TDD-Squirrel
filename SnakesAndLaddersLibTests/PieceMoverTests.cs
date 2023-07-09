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

            var result = _sut.Move(previousPosition, 10);
            result.Position.Should().Be(expected);

        }

        [TestCase(9, 10, true)]
        [TestCase(0, 10, false)]
        [TestCase(10, 15, true)]
        [TestCase(9, 15, false)]
        [TestCase(0, 15, false)]
        public void Move_Should_Return_GameStatus(int position, int numberOfFields, bool expected)
        {
            A.CallTo(() => _diceRoller.RollDie()).Returns(5);
            var result = _sut.Move(position, numberOfFields);
            result.IsFinalSquareReached.Should().Be(expected);
        }

        [Test]
        public void Move_Should_Return_CorrectPosition_OnBoard_ForOneSquare()
        {
            var position = 0;
            const int rows = 1;
            const int columns = 1;
            var board = new bool[rows, columns]  { { false} };
            A.CallTo(() => _diceRoller.RollDie()).Returns(1);

            var result = _sut.Move(position, board);

            var expectedPosition = (0, 0);
            result.Position.Should().Be(expectedPosition);
        }

    }
}
