using StarWars.App.Data.Repositories;
using StarWarsApp.Data.Infra;
using System.Threading.Tasks;
using Xunit;

namespace StarWars.Tests
{
	public class StarShipRepositoryTests
	{
		[Fact]
		public async Task GetAsync_GivenCorrectUrl_ShouldReturnStarShipsDto()
		{ 
			//Arrange
			string url = Config.StarShipsBaseUrl + "/?page=1";

			//Act
			var starshipDto = await new StarShipRepository().GetAsync(url);
 
			//Assert
			Assert.NotNull(starshipDto);
			Assert.NotEmpty(starshipDto.StarShips);
		}
	}
}
