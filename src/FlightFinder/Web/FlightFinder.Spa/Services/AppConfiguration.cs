using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightFinder.Common.Models;

namespace FlightFinder.Spa.Services
{
    public class AppConfiguration : Common.Services.IAppConfiguration
    {
        public Enums.ClientType ClientType => Enums.ClientType.Spa;
        public string BaseServerAddress => null;
    }
}
