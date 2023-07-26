using FluentAssertions;
using SnakesAndLadders;

namespace SnakesAndLaddersTests
{
    public class DiceRollerTests
    {
        private IDiceRoller _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DiceRoller();
        }

        [Test]
        public void Roll_Die_Return_Int_Range_1_to_6()
        {
            var results = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                var result = _sut.RollDie();
                results.Add(result);
            }

            results.Should().Contain(1);
            results.Should().Contain(2);
            results.Should().Contain(3);
            results.Should().Contain(4);
            results.Should().Contain(5);
            results.Should().Contain(6);
        }

        [Test]
        public void RollDie_Should_Return_IntInRange1To6()
        {
            var result = _sut.RollDie();
            result.Should().BeOfType(typeof(int));
            result.Should().BeInRange(1, 6);

        }
    }
}