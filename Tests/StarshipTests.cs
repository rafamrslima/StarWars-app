using StarWars.App.Domain.Entities;
using StarWars.App.Domain.Exceptions;
using System;
using Xunit;

namespace StarWars.Tests
{
    public class StarShipTests
    { 
        [Theory]
        [InlineData("5 decades", "2600")]
        public void GetStops_InvalidTimeUnit_ShouldReturnUnknown(string consumables, string megalights)
        {
            // Arrange 
            var starship = new StarShip( "Millennium Falcon:", megalights, consumables);
            var expected = "unknown";

            // Act
            Action act = () => starship.GetStops(1000000);

            // Assert
            Assert.Equal(expected, Assert.Throws<DomainException>(act).Message);
        }

        [Theory]
        [InlineData("-2600", "5 years")]
        public void GetStops_NegativeMegalights_ShouldReturnUnknown(string megalights, string consumables)
        {
            // Arrange 
            var starship = new StarShip( "Millennium Falcon:", megalights, consumables);
            var expected = "unknown";

            // Act
            Action act = () => starship.GetStops(1000000);

            // Assert
            Assert.Equal(expected, Assert.Throws<DomainException>(act).Message);
        }

        [Theory]
        [InlineData("22000", "5 days")]
        public void GetStops_ValidDays_ShouldCalculateStops(string megalights, string consumables)
        {
            // Arrange 
            var starship = new StarShip( "Millennium Falcon:", megalights, consumables);
            var distanceBetweenStops = 24 * Convert.ToInt32(consumables.Split(' ')[0]) * Convert.ToInt32(megalights);
            var expected = Math.Round(1000000 / (double)distanceBetweenStops, MidpointRounding.AwayFromZero);

            // Act
            var actual = starship.GetStops(1000000);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("80", "3 weeks")]
        public void GetStops_ValidWeeks_ShouldCalculateStops(string megalights, string consumables)
        {
            // Arrange 
            var starship = new StarShip( "Millennium Falcon:", megalights, consumables);
            var distanceBetweenStops = 24 * 7 * Convert.ToInt32(consumables.Split(' ')[0]) * Convert.ToInt32(megalights);
            var expected = Math.Round(1000000 / (double)distanceBetweenStops, MidpointRounding.AwayFromZero);

            // Act
            var actual = starship.GetStops(1000000);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("40", "2 months")]
        public void GetStops_ValidMonths_ShouldCalculateStops(string megalights, string consumables)
        {
            // Arrange
            var starship = new StarShip( "Millennium Falcon:", megalights, consumables);
            var startDate = DateTime.UtcNow;
            var endDate = startDate.AddMonths(Convert.ToInt32(consumables.Split(' ')[0]));
            var distanceBetweenStops = (endDate - startDate).TotalHours * Convert.ToInt32(megalights);
            var expected = Math.Round(1000000 / distanceBetweenStops, MidpointRounding.AwayFromZero);

            // Act
            var actual = starship.GetStops(1000000);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("9000", "1 year")]
        public void GetStops_ValidYears_ShouldCalculateStops(string megalights, string consumables)
        {
            // Arrange 
            var starship = new StarShip( "Millennium Falcon:", megalights, consumables);
            var startDate = DateTime.UtcNow;
            var endDate = startDate.AddYears(Convert.ToInt32(consumables.Split(' ')[0]));
            var distanceBetweenStops = (endDate - startDate).TotalHours * Convert.ToInt32(megalights);
            var expected = Math.Round(1000000 / distanceBetweenStops, MidpointRounding.AwayFromZero);

            // Act
            var actual = starship.GetStops(1000000);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("100")]
        public void GetStops_UnknownConsumables_ShouldReturnUnknown(string megalights)
        {
            // Arrange
            var starship = new StarShip( "Millennium Falcon:", megalights, "unknown");
            var expected = "unknown";

            // Act
            Action act = () => starship.GetStops(1000000);

            // Assert
            Assert.Equal(expected, Assert.Throws<DomainException>(act).Message);

        }

        [Theory]
        [InlineData("5 years")]
        public void GetStops_UnknownMegalights_ShouldReturnUnknown(string duration)
        {
            // Arrange
            var starship = new StarShip( "Millennium Falcon:", "unknown", duration);
            var expected = "unknown";

            // Act
            Action act = () => starship.GetStops(1000000);

            // Assert
            Assert.Equal(expected, 
                Assert.Throws<DomainException>(act).Message);
        }
    }
}
