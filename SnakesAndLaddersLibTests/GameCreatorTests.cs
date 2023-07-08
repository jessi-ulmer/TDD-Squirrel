using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;
namespace SnakesAndLaddersLibTests;

    public class GameCreatorTests
    {


        [Test]
        public void CreateGame_Should_Return_InitializedGame_ForGivenNumberOfFields()
        {
            var game = GameCreator.CreateGame(15);

            using var scope = new AssertionScope();
            game.Should().NotBeNull();
            game.IsDieDisabled.Should().BeFalse();
            game.Status.Should().BeTrue();
            game.Position.Should().Be(0);
            game.NumberOfFields.Should().Be(15);
        }
    }
    
