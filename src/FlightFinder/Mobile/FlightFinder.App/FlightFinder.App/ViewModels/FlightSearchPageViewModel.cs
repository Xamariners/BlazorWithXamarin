using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightFinder.Common.Models;
using FlightFinder.Common.Services;
using FlightFinder.Shared.States;

namespace FlightFinder.App.ViewModels
{
    public class FlightSearchPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public IEnumerable<Itinerary> Itineraries { get; set; }

        public FlightSearchState FlightSearchState { get; set; }
        
        public DelegateCommand SearchCommand { get; set; }

        public IEnumerable<Airport> Airports { get; set; }

        public int FromAirportsSelectedIndex { get; set; }

        public int ToAirportsSelectedIndex { get; set; }

        public FlightSearchPageViewModel(INavigationService navigationService, FlightSearchState flightSearchState)
            : base(navigationService)
        {
            Title = "Main Page";
            FlightSearchState = flightSearchState;
            SearchCommand = new DelegateCommand(Search);
        }

        private async void Search()
        {
            var criteria = new SearchCriteria(Airports.ToArray()[FromAirportsSelectedIndex].DisplayName,
                Airports.ToArray()[ToAirportsSelectedIndex].DisplayName);
            
            await FlightSearchState.SearchFlights(criteria);

            Itineraries = FlightSearchState.SearchResults;
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            Airports = await FlightSearchState.GetAllAirports();
            base.OnNavigatingTo(parameters);
        }
    }
}