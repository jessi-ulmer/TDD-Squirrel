using System.Diagnostics;
using FakeItEasy;
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

    //[TestCase(0, 1, 1)]
    //[TestCase(5, 2, 7)]
    //[TestCase(5, 5, 10)]
    //[TestCase(7, 6, 10)]
    //public void Move_Should_Return_PositionInRange(int previousPosition, int fakedDie, int expected)
    //{
    //    A.CallTo(() => _diceRoller.RollDie()).Returns(fakedDie);
    //    using var assertionScope = new AssertionScope();

    //    var result = _sut.Move(previousPosition, 10);
    //    result.Position.Should().Be(expected);

    //}

    [Test]
    public void Move_Should_Return_Result_ForMovingOneSquare()
    {
        A.CallTo(() => _diceRoller.RollDie()).Returns(1);
        var previousPosition = (1, 0);
        var rows = 2;
        var columns = 2;
        var result = _sut.Move(previousPosition, rows, columns);

        using var assertionScope = new AssertionScope();

        var expectedPosition = (1, 1);
        result.Position.Should().Be(expectedPosition);
        result.IsFinalSquareReached.Should().BeFalse();
    }

    [Test]
    public void Code_In_Test_StartPlus1()
    {
        var previousPosition = (1, 0);
        const int movement = 1;
        var expectedPosition = (1, 1);

        var result = (previousPosition.Item1, previousPosition.Item2 + movement);

        result.Should().Be(expectedPosition);
    }

    [Test]
    public void Code_In_Test_1_1_Plus1()
    {
        var previousPosition = (1, 1);
        const int movement = 1;
        var expectedPosition = (0, 1);

        var result = (previousPosition.Item1 - movement, previousPosition.Item2);

        result.Should().Be(expectedPosition);
    }

    [Test]
    public void Code_In_Test_0_1_Plus1()
    {
        var previousPosition = (0, 1);
        const int movement = 1;
        var expectedPosition = (0, 0);

        var result = (previousPosition.Item1, previousPosition.Item2 - movement);

        result.Should().Be(expectedPosition);
    }

    [TestCaseSource(nameof(CreateMovingTestData))]
    public void Move_Should_Return_Position((int, int) previousPosition, int movement, (int, int) expectedPosition)
    {
        var result = (previousPosition) switch
        {
            (1, 0) => (previousPosition.Item1, previousPosition.Item2 + 1),
            (1, 1) => (previousPosition.Item1 - 1, previousPosition.Item2),
            (0, 1) => (previousPosition.Item1, previousPosition.Item2 - 1),
            _ => throw new InvalidOperationException()
        };

        result.Should().Be(expectedPosition);
    }

    private static IEnumerable<TestCaseData> CreateMovingTestData()
    {
        yield return new TestCaseData((1, 0), 1, (1, 1));
        yield return new TestCaseData((1, 1), 1, (0, 1));
        yield return new TestCaseData((0, 1), 1, (0, 0));
        yield return new TestCaseData((1, 0), 2, (0, 1));
        yield return new TestCaseData((1, 1), 2, (0, 0));
    }


    //[TestCase(9, 10, true)]
    //[TestCase(0, 10, false)]
    //[TestCase(10, 15, true)]
    //[TestCase(9, 15, false)]
    //[TestCase(0, 15, false)]
    //public void Move_Should_Return_GameStatus(int position, int numberOfFields, bool expected)
    //{
    //    A.CallTo(() => _diceRoller.RollDie()).Returns(5);
    //    var result = _sut.Move(position, numberOfFields);
    //    result.IsFinalSquareReached.Should().Be(expected);
    //}
}