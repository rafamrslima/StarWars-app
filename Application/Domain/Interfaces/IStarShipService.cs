using StarWars.App.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWars.App.Domain.Interfaces
{
    public interface IStarShipService
    {
        Task<List<StarShip>> GetAllAsync();
    }
}
