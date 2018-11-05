using System;
using System.Collections.Generic;
using System.Text;
using FlightFinder.Common.Models;

namespace FlightFinder.Common.Services
{
    public interface IAppConfiguration
    {
        Enums.ClientType ClientType { get; }
        string BaseServerAddress { get; }
    }
}
