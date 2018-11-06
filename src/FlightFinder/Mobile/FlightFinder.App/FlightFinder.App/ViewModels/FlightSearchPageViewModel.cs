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
using FlightFinder.Shared.ViewModels;

namespace FlightFinder.App.ViewModels
{
    public class FlightSearchPageViewModel : ViewModelBase
    {
        public FlightSearchState FlightSearchState { get; set; }
       
        public DelegateCommand<SearchCriteria> SearchCommand { get; set; }

        public FlightSearchPageViewModel(INavigationService navigationService, FlightSearchState flightSearchState)
            : base(navigationService)
        {
            Title = "Main Page";
            FlightSearchState = flightSearchState;
            SearchCommand = new DelegateCommand<SearchCriteria>(async (criteria) => await FlightSearchState.Search(criteria));
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }
    }
}