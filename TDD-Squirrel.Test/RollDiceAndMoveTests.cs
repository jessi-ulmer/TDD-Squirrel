using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace TDD_Squirrel.Test
{
    public class RollDiceAndMoveTests
    {
        [Test]
        public void SetUpTest()
        {
            var result = true;
            result.Should().BeTrue();  
        }
    }
}
