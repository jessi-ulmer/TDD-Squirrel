﻿using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests
{
    public class RollDiceAndMoveTests
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
        public void SetUpTest()
        {
            var result = true;
            result.Should().BeTrue();  
        }

        [Test]
        public void RandomGeneratorFunctionTest()
        {
            var generator = new Random(0);
            var result = generator.Next(7);

            using var scope1 = new AssertionScope();
            result.Should().BeInRange(1, 6);
            result.Should().Be(5);
            result = generator.Next(7);
            result.Should().Be(5);
            var results = new[] { generator.Next(7), generator.Next(7), generator.Next(7), generator.Next(7) };

            using var scope2 = new AssertionScope();
            results.Should().BeEquivalentTo(new[] { 5, 3, 1, 3 });

            using var scope3 = new AssertionScope();
            for (var i = 0; i < 100; i++)
            {
                result = generator.Next(1, 7);
                result.Should().NotBe(0);
                result.Should().BeInRange(1, 6);
            }

        }

        [Test]
        public void RollDice_Should_Return_Integer_Between_1_And_6()
        {
            var diceRoller = new DiceRoller();
            var result = diceRoller.RollDie();
            result.Should().BeInRange(1, 6);
        }

        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 2)]
        [TestCase(5, 5, 10)]
        [TestCase(5, 6, 10)]
        public void CalculatePosition_Should_Return_NewPosition(int previousPosition, int diceRoll, int expected)
        {
            var result = PieceMover.CalculatePosition(previousPosition, diceRoll);
            result.Should().Be(expected);
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