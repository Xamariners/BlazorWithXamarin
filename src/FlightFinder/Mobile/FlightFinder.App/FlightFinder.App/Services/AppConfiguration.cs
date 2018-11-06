using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightFinder.Common.Models;

namespace FlightFinder.App.Services
{
    public class AppConfiguration : Common.Services.IAppConfiguration
    {
        public Enums.ClientType ClientType => Enums.ClientType.Mobile;
        public string BaseServerAddress => "http://10.211.55.3:2167";
    }
}
