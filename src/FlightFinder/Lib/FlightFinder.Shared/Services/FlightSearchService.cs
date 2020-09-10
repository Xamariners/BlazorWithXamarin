using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FlightFinder.Common.Models;
using FlightFinder.Common.Services;

namespace FlightFinder.Shared.Services
{
    public class FlightSearchService : ServiceBase, IFlightSearchService
    {
        public FlightSearchService(HttpClient httpClient, IAppConfiguration configuration) : base(httpClient, configuration)
        {
        }

        public async Task<IEnumerable<Itinerary>> Search(SearchCriteria criteria)
        {
            var address = "/api/flightsearch";

            var response = await _httpClient.PostAsJsonAsync(address, criteria);
            var result = await response.Content.ReadFromJsonAsync<Itinerary[]>();
            return result;
        }
    }
}
