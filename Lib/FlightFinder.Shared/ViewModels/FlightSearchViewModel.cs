using FlightFinder.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightFinder.Common.Services;

namespace FlightFinder.Shared.ViewModels
{
    public class FlightSearchViewModel
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

        public FlightSearchViewModel(IFlightSearchService flightSearchService)
        {
            _flightSearchService = flightSearchService;
        }

        public async Task Search(SearchCriteria criteria)
        {
            SearchInProgress = true;
            NotifyStateChanged();
            SearchResults = await _flightSearchService.Search(criteria) as IReadOnlyList<Itinerary>;
            SearchInProgress = false;
            NotifyStateChanged();
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
