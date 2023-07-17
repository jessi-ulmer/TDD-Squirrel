using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Win32.SafeHandles;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests;

public class GameCreatorTests
{
    [TestCase(1, 1, 1)]
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