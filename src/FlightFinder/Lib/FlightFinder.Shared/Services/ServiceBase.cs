using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightFinder.Common.Models;
using FlightFinder.Common.Services;

namespace FlightFinder.Shared.Services
{
    public class ServiceBase
    {   
        protected HttpClient _httpClient;
        protected readonly IAppConfiguration _configuration;

        public ServiceBase(HttpClient httpClient, IAppConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            if(configuration.BaseServerAddress != null)
                _httpClient.BaseAddress = new Uri(_configuration.BaseServerAddress);
        }
    }
}