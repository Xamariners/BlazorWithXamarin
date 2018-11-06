using FlightFinder.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FlightFinder.Shared;

namespace FlightFinder.Server.Controllers
{
    [Route("api/[controller]")]
    public class AirportsController : Controller
    {
        public IEnumerable<Airport> Airports()
        {
            return SampleData.Airports;
        }
    }
}
