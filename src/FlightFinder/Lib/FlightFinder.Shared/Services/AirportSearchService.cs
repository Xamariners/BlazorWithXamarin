using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightFinder.Common.Models;
using FlightFinder.Common.Services;
using Microsoft.AspNetCore.Blazor;

namespace FlightFinder.Shared.Services
{
    public class AirportSearchService : ServiceBase, IAirportSearchService
    {
 
        public AirportSearchService(HttpClient httpClient, IAppConfiguration configuration) : base(httpClient, configuration)
        {  
        }

        public async Task<IEnumerable<Airport>> GetAllAirports()
        {
            var result = await _httpClient.GetJsonAsync<Airport[]>("/api/airports");
            return result;
        }
    }
}
