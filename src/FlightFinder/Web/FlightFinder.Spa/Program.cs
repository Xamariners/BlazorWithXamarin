using System;
using System.Net.Http;
using System.Threading.Tasks;
using FlightFinder.Common.Services;
using FlightFinder.Shared.Services;
using FlightFinder.Shared.States;
using FlightFinder.Spa.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FlightFinder.Spa
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddSingleton<IAppConfiguration, AppConfiguration>();
            builder.Services.AddSingleton<FlightSearchState>();
            builder.Services.AddSingleton<IFlightSearchService, FlightSearchService>();
            builder.Services.AddSingleton<IAirportSearchService, AirportSearchService>();

            builder.RootComponents.Add<Main>("app");
            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
