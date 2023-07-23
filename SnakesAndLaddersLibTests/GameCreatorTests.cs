using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Win32.SafeHandles;
using Snapshooter.NUnit;
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
        }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(10)]
    public void CreateGame_Should_Match_snapshot(int size)
    {
        var game = GameCreator.CreateGame(size);
        game.Should().MatchSnapshot();
    }
}