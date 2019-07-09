using FlightFinder.Common.Services;
using FlightFinder.Shared.Services;
using FlightFinder.Shared.States;
using FlightFinder.Spa.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FlightFinder.Spa
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppConfiguration, AppConfiguration>();
            services.AddSingleton<FlightSearchState>();
            services.AddScoped<IFlightSearchService, FlightSearchService>();
            services.AddScoped<IAirportSearchService, AirportSearchService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<Main>("body");
        }
    }
}
