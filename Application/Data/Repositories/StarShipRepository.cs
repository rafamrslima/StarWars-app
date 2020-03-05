using StarWars.App.Domain.Interfaces;
using StarWars.App.Services.Dtos;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace StarWars.App.Data.Repositories
{
    public class StarShipRepository : IStarShipRepository
    {
        public async Task<StarWarsDto> GetAsync(string url)
        { 
            var request = WebRequest.Create(url);
            var response = await request.GetResponseAsync();
            var jsonSerializer = new DataContractJsonSerializer(typeof(StarWarsDto));
            var objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
            var result = objResponse as StarWarsDto;

            return result;
        }
    }
}
