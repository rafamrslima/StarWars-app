using StarWars.App.Domain.Entities;
using StarWars.App.Domain.Interfaces;
using StarWars.App.Services.Dtos;
using StarWarsApp.Data.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace StarWars.App.Services
{
    public class StarShipService : IStarShipService
    {
        readonly IStarShipRepository _starShipRepository;

        public StarShipService(IStarShipRepository starShipRepository)
        {
            _starShipRepository = starShipRepository;
        }

        public async Task<List<StarShip>> GetAllAsync()
        {
            int page = 1;
            var url = $"{Config.StarShipsBaseUrl}/?page={page}";

            var starShipDto = new StarWarsDto() { NextPageUrl = url };
            var starShips = new List<StarShip>();

            while (starShipDto.NextPageUrl != null)
            {
                starShipDto = await _starShipRepository.GetAsync(starShipDto.NextPageUrl);

                starShips.AddRange(from starShip in starShipDto.StarShips
                                   select new StarShip(starShip.Name, starShip.Megalights, starShip.Consumables));
            }

            return starShips;
        }
    }
}
