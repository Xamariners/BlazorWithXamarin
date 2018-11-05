using FlightFinder.Common.Services;
using FlightFinder.Shared.Services;
using FlightFinder.Shared.ViewModels;
using FlightFinder.Spa.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FlightFinder.Spa
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAppConfiguration, AppConfiguration>();
            services.AddSingleton<FlightSearchViewModel>();
            services.AddScoped<IFlightSearchService, FlightSearchService>();
            services.AddScoped<IAirportSearchService, AirportSearchService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<Main>("body");
        }
    }
}
