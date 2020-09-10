using FlightFinder.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FlightFinder.Shared;

namespace FlightFinder.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportsController : ControllerBase
    {
        public IEnumerable<Airport> Airports()
        {
            return SampleData.Airports;
        }
    }
}
