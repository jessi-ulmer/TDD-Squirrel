using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;
namespace SnakesAndLaddersLibTests;

    public class GameCreatorTests
    {


        [TestCase(10)]
        [TestCase(15)]
        public void CreateGame_Should_Return_InitializedGame_ForGivenNumberOfFields(int numberOfFields)
        {
            var game = GameCreator.CreateGame(numberOfFields);

            using var scope = new AssertionScope();
            game.Should().NotBeNull();
            game.IsDieDisabled.Should().BeFalse();
            game.Status.Should().BeTrue();
            game.Position.Should().Be(0);
            game.NumberOfFields.Should().Be(numberOfFields);
        }

        [Test]
        public void CreateGame_Should_Return_SquareGame()
        {
            var game = GameCreator.CreateGame(1);

            using var scope = new AssertionScope();
            game.Should().NotBeNull();
            game.Status.Should().BeTrue();
            game.Position.Should().Be(0);
            game.NumberOfFields.Should().Be(1);
            game.Rows.Should().Be(1);
            game.Columns.Should().Be(1);
    }
    }
    
