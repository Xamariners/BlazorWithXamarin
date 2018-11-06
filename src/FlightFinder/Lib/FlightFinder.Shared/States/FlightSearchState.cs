using FlightFinder.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightFinder.Common.Services;

namespace FlightFinder.Shared.States
{
    public class FlightSearchState
    {
        // Actual state
        public IReadOnlyList<Itinerary> SearchResults { get; private set; }
        public bool SearchInProgress { get; private set; }

        private readonly List<Itinerary> shortlist = new List<Itinerary>();
        public IReadOnlyList<Itinerary> Shortlist => shortlist;

        // Lets components receive change notifications
        // Could have whatever granularity you want (more events, hierarchy...)
        public event Action OnChange;
        
        private readonly IFlightSearchService _flightSearchService;
        private readonly IAirportSearchService _airportSearchService;

        public FlightSearchState(IFlightSearchService flightSearchService, IAirportSearchService airportSearchService)
        {
            _flightSearchService = flightSearchService;
            _airportSearchService = airportSearchService;
        }

        public async Task SearchFlights(SearchCriteria criteria)
        {
            SearchInProgress = true;
            NotifyStateChanged();
            SearchResults = await _flightSearchService.Search(criteria) as IReadOnlyList<Itinerary>;
            SearchInProgress = false;
            NotifyStateChanged();
        }

        public async Task<IEnumerable<Airport>> GetAllAirports()
        {
            var airports = await _airportSearchService.GetAllAirports();
            return airports;
        }

        public void AddToShortlist(Itinerary itinerary)
        {
            shortlist.Add(itinerary);
            NotifyStateChanged();
        }

        public void RemoveFromShortlist(Itinerary itinerary)
        {
            shortlist.Remove(itinerary);
            NotifyStateChanged();
        }

        protected void NotifyStateChanged() => OnChange?.Invoke();
    }
}
