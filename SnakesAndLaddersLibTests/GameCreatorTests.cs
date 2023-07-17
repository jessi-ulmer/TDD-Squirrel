using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Win32.SafeHandles;
using SnakesAndLaddersLib;
namespace SnakesAndLaddersLibTests;

    public class GameCreatorTests
    {


        [TestCase(4)]
        [TestCase(3)]
        public void CreateGame_Should_Return_InitializedGame_ForGivenNumberOfFields(int size)
        {
            var game = GameCreator.CreateGame(size);

            using var scope = new AssertionScope();
            game.Should().NotBeNull();
            game.IsDieDisabled.Should().BeFalse();
            game.Status.Should().BeTrue();
            game.Position.Should().Be(0);
            game.Board.Length.Should().Be(size*size); 
            game.Board.GetLength(0).Should().Be(size);  
            game.Board.GetLength(1).Should().Be(size);
        }

        [Test]
        public void CreateGame_Should_Return_SquareBoard()
        {
            var game = GameCreator.CreateGame(4);

            var expectedBoard = new bool[4, 4]
            {
                { false, false, false, false }, { false, false, false, false }, { false, false, false, false },
                { false, false, false, false }
            };
            game.Board.Should().BeEquivalentTo(expectedBoard);

        }
    }
    
