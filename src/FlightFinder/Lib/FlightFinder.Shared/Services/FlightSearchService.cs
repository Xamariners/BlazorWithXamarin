using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightFinder.Common.Models;
using FlightFinder.Common.Services;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;


namespace FlightFinder.Shared.Services
{
    public class FlightSearchService : ServiceBase, IFlightSearchService
    {  
        public FlightSearchService(HttpClient httpClient, IAppConfiguration configuration) : base (httpClient, configuration)
        {
        }
        
        public async Task<IEnumerable<Itinerary>> Search(SearchCriteria criteria)
        {
            var address = "/api/flightsearch";

            var result = await _httpClient.PostJsonAsync<IEnumerable<Itinerary>>(address, criteria);
            return result;
        }
    }
}
