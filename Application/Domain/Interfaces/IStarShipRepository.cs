using StarWars.App.Services.Dtos;
using System.Threading.Tasks;

namespace StarWars.App.Domain.Interfaces
{
    public interface IStarShipRepository
    {
        Task<StarWarsDto> GetAsync(string url);
    }
}
