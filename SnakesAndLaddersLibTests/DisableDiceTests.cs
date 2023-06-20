using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using SnakesAndLaddersLib;

namespace SnakesAndLaddersLibTests
{
    public class DisableDiceTests
    {

        [Test]
        public void PieceMover_Should_Return_FinishReached()
        {
            var diceRoller = A.Fake<IDiceRoller>();
            A.CallTo(() => diceRoller.RollDie()).Returns(5);
            var pieceMover = new PieceMover(diceRoller);
            var movingResult = pieceMover.Move(5);
            movingResult.Position.Should().Be(10);
            movingResult.IsFinalSquareReached.Should().BeTrue();


        }

    }
}
