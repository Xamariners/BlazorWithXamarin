using System.Collections.Generic;
using System.Threading.Tasks;
using FlightFinder.Common.Models;

namespace FlightFinder.Common.Services
{
    public interface IAirportSearchService
    {
        Task<IEnumerable<Airport>> GetAllAirports();
    }
}