using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightFinder.Common.Models;
using FlightFinder.Common.Services;

namespace FlightFinder.App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IFlightSearchService _flightSearchService;
        public IReadOnlyList<Itinerary> SearchResults { get; private set; }

        public DelegateCommand RefreshCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IFlightSearchService flightSearchService)
            : base(navigationService)
        {
            Title = "Main Page";
            _flightSearchService = flightSearchService;
            RefreshCommand = new DelegateCommand(async () => await Refresh());
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }

        public async Task Refresh()
        {
            var criteria = new SearchCriteria("SIN", "SEA");

            try
            {
                SearchResults = await _flightSearchService.Search(criteria) as IReadOnlyList<Itinerary>;
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}
