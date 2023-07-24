using Bunit;
using TDD_Squirrel.Pages;

namespace TDD_Squirrel.Test
{
    public class GameTests
    {
        [Test]
        public void GamePreparationIsVisible()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();

            const string preparationHtml = @"<h4 >Spielvorbereitung</h4>
    <div class=""game-preparation"" >
      <span class=""input-content"" >
        <input type=""number"" class=""input-numbers"" name=""numberOfFieldsInput"" min=""0"" max=""10"" value=""1""  >
        <label >Anz. Spielfelder (Quadratisch)</label>
      </span>
      <br >
      <button  class=""btn btn-primary button-peparation"" >Spielstart - Let's play</button>
    </div>";

            // Act
            var component = ctx.RenderComponent<Game>();


            // Assert
            component.MarkupMatches(preparationHtml);
        }
    }
}
