using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests
{
    public class DisableDiceTests
    {
        private IDiceRoller _diceRoller;
        private PieceMover _sut;

        [SetUp]
        public void SetUp()
        {
            _diceRoller = A.Fake<IDiceRoller>();
            _sut = new PieceMover(_diceRoller);
        }

        [Test]
        public void PieceMover_Should_Return_FinishReached()
        {
            var diceRoller = A.Fake<IDiceRoller>();
            A.CallTo(() => diceRoller.RollDie()).Returns(5);
            var pieceMover = new PieceMover(diceRoller);
            var movingResult = pieceMover.Move(5);
            movingResult.Position.Should().Be(10);
            movingResult.IsFinalSquareReached.Should().BeTrue();
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
