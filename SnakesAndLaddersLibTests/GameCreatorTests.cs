using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;
namespace SnakesAndLaddersLibTests;

    public class GameCreatorTests
    {


        [TestCase(4)]
        [TestCase(3)]
        public void CreateGame_Should_Return_InitializedGame_ForGivenNumberOfFields(int numberOfFields)
        {
            var game = GameCreator.CreateGame(numberOfFields);

            using var scope = new AssertionScope();
            game.Should().NotBeNull();
            game.IsDieDisabled.Should().BeFalse();
            game.Status.Should().BeTrue();
            game.Position.Should().Be(0);
            game.Board.Should().HaveCount(numberOfFields);
        }

        [Test]
        public void CreateGame_Should_Return_SquareBoard()
        {
            var game = GameCreator.CreateGame(4);

            game.Board.Should().HaveCount(4);
            game.Board.First().Should().HaveCount(4);
            foreach (var row in game.Board)
            {
                foreach (var square in row)
                {
                    square.Should().BeFalse();
                }
            }
        }
    }
    
