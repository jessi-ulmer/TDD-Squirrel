using System.Diagnostics;
using FakeItEasy;
using FakeItEasy.Core;
using FluentAssertions;
using FluentAssertions.Execution;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests;

public class PieceMoverTests
{
    private IDiceRoller _diceRoller;
    private PieceMover _sut;

    [SetUp]
    public void SetUp()
    {
        _diceRoller = A.Fake<IDiceRoller>();
        _sut = new PieceMover(_diceRoller);
    }


    [TestCaseSource(nameof(CreateMovingTestData))]
    public void PieceMoverMove_Should_Return_Position(Position previousPosition, int movement, int rows, int columns, Position expectedPosition, bool expectedFinalSquare)
    {
        A.CallTo(() => _diceRoller.RollDie()).Returns(movement);
        var result = _sut.Move(previousPosition, rows, Array.Empty<Ladder>());

        var expectation = new MovingResult(expectedPosition, movement, expectedFinalSquare);
        result.Should().Be(expectation);
    }

    private static IEnumerable<TestCaseData> CreateMovingTestData()
    {
        yield return new TestCaseData(new Position(0, 1), 1, 2, 2, new Position(1,1 ), false);
        yield return new TestCaseData(new Position(1, 1), 1, 2, 2, new Position(1,0 ), false);
        yield return new TestCaseData(new Position(1, 0), 1, 2, 2, new Position(0,0 ), true);
        yield return new TestCaseData(new Position(0, 1), 2, 2, 2, new Position(1,0 ), false);
        yield return new TestCaseData(new Position(1, 1), 2, 2, 2, new Position(0,0 ), true);
        yield return new TestCaseData(new Position(0, 1), 3, 2, 2, new Position(0,0 ), true);
        yield return new TestCaseData(new Position(0, 2), 1, 3, 3, new Position(1,2 ), false);
        yield return new TestCaseData(new Position(0, 2), 2, 3, 3, new Position(2,2 ), false);
        yield return new TestCaseData(new Position(2, 2), 1, 3, 3, new Position(2,1 ), false);
        yield return new TestCaseData(new Position(2, 1), 1, 3, 3, new Position(1,1 ), false);
        yield return new TestCaseData(new Position(2, 1), 3, 3, 3, new Position(0,0 ), false);
        yield return new TestCaseData(new Position(2, 1), 5, 3, 3, new Position(2,0 ), true);
        yield return new TestCaseData(new Position(1, 1), 4, 4, 4, new Position(2,0 ), false);
        yield return new TestCaseData(new Position(0, 1), 4, 2, 2, new Position(0,0 ), true).SetName("Stop at End, Size 2");
        yield return new TestCaseData(new Position(3, 0), 4, 4, 4, new Position(0,0 ), true).SetName("Stop at End, Size 4");
        yield return new TestCaseData(new Position(0, 1), 4, 3, 3, new Position(2,0 ), true).SetName("Stop at End, Size 3");
    }
}