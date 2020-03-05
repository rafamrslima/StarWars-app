using StarWars.App.Data.Repositories;
using StarWars.App.Domain.Entities;
using StarWars.App.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StarWars.Tests
{
	public class StarShipServiceTests
    {
		[Fact]
		public async Task StarShipService_GetAllAsync_ShouldReturnStarships()
		{
			//Arrange
			var starshipService = new StarShipService(new StarShipRepository());

			//Act
			var starShips = await starshipService.GetAllAsync();

			//Assert
			Assert.NotNull(starShips);
			Assert.IsType<List<StarShip>>(starShips);
			Assert.NotEmpty(starShips);
		}
	}
}
