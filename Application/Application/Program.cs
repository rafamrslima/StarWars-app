using Microsoft.Extensions.DependencyInjection;
using StarWars.App.Domain.Interfaces;
using System.Threading.Tasks;

namespace StarWarsApp.Application
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Startup.ConfigureServices(out ServiceProvider serviceProvider);

			await new StarWarsApp(serviceProvider.GetService<IStarShipService>())
				.StartApplicationAsync();
		}
	}
}
