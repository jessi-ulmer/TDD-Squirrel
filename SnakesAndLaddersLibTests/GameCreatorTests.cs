using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;
namespace SnakesAndLaddersLibTests;

    public class GameCreatorTests
    {


        [Test]
        public void CreateGame_Should_Return_NotNull()
        {
            var game = GameCreator.CreateGame();
            game.Should().NotBeNull();
        //DisabledDie = game.IsDieDisabled;
        //ShowGame = game.Status;
        //PiecePosition = game.Position;
        //NumberOfFields = game.NumberOfFields;
        }
    }
    
