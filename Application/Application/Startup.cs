using Microsoft.Extensions.DependencyInjection;
using StarWars.App.Data.Repositories;
using StarWars.App.Domain.Interfaces;
using StarWars.App.Services;

namespace StarWarsApp.Application
{
    public class Startup
    {
        public static void ConfigureServices(out ServiceProvider serviceProvider)
        {
            //setup our DI
            serviceProvider = new ServiceCollection()
               .AddSingleton<IStarShipService, StarShipService>()
               .AddSingleton<IStarShipRepository, StarShipRepository>()
               .BuildServiceProvider();
        }
    }
}
