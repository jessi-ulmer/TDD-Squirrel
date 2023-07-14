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

        }

        [TestCase(1, 1,1)]
        [TestCase(2, 2, 2)]
        public void CrateGame_Should_Return_SquareGame(int size, int expectedRows, int expectedColumns)
        {
            var game = GameCreator.CreateGame(size);

            using var scope = new AssertionScope();
            game.Should().NotBeNull();
            game.IsDieDisabled.Should().BeFalse();
            game.Status.Should().BeTrue();

            game.Rows.Should().Be(expectedRows);
            game.Columns.Should().Be(expectedColumns);

        }
}
    
