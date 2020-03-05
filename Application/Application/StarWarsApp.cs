using Microsoft.Extensions.DependencyInjection;
using StarWars.App.Domain.Entities;
using StarWars.App.Domain.Exceptions;
using StarWars.App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsApp.Application
{
    public class StarWarsApp
    {
        readonly IStarShipService _starShipService;

        public StarWarsApp(IStarShipService starShipService)
        {
            _starShipService = starShipService;
        }

        public async Task StartApplicationAsync()
        {
            int distance;
            string inputDistanceMessage = "Enter the distance in mega lights: ";

            Console.Write(inputDistanceMessage);

            while (!int.TryParse(Console.ReadLine(), out distance) || distance <= 0)
            {
                Console.WriteLine("The distance should be a value greater than 0.");
                Console.Write(inputDistanceMessage);
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine("Getting data...");
            Console.WriteLine(string.Empty);

            List<StarShip> starships = await _starShipService.GetAllAsync();

            foreach (var starship in starships)
            {
                try
                {
                    Console.WriteLine($"{starship.Name}: {starship.GetStops(distance)}");
                }
                catch (DomainException ex)
                {
                    Console.WriteLine($"{starship.Name}: {ex.Message}");
                }
            }
 

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
