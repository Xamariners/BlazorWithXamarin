using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FlightFinder.Common.Models;
using FlightFinder.Shared.States;
using Prism.Services;

namespace FlightFinder.App.ViewModels
{
    public class FlightSearchPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IPageDialogService _pageDialogService;
        public IEnumerable<Itinerary> Itineraries { get; set; }

        public FlightSearchState FlightSearchState { get; set; }

        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand<Itinerary> AddCommand { get; set; }

        public IEnumerable<Airport> Airports { get; set; }

        public int FromAirportsSelectedIndex { get; set; }

        public int ToAirportsSelectedIndex { get; set; }

        public FlightSearchPageViewModel(INavigationService navigationService, FlightSearchState flightSearchState, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            Title = "Flight Finder (Empty Basket)";
            FlightSearchState = flightSearchState;
            SearchCommand = new DelegateCommand(Search);
            AddCommand = new DelegateCommand<Itinerary>(Add);
        }

        public override async void OnAppearing()
        {
            await GetAllAirports();
        }

        private async void Search()
        {
            if (Airports is null) await GetAllAirports();

            var criteria = new SearchCriteria(Airports.ToArray()[FromAirportsSelectedIndex].Code,
                Airports.ToArray()[ToAirportsSelectedIndex].Code);

            await FlightSearchState.SearchFlights(criteria);

            Itineraries = FlightSearchState.SearchResults;
        }

        private void Add(Itinerary itinerary)
        {
            FlightSearchState.AddToShortlist(itinerary);
            Title = $"Flight Finder (Basket: {FlightSearchState.Shortlist.Count})";
        }

        private async Task GetAllAirports()
        {
            try
            {
                Airports = await FlightSearchState.GetAllAirports().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Error", ex.Message, "Okay");
            }

            if (Airports != null && Airports.Count() > 1)
            {
                // set default airports
                FromAirportsSelectedIndex = 1;
                ToAirportsSelectedIndex = 2;
            }
        }
    }
}