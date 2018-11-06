using FlightFinder.App.Services;
using Prism;
using Prism.Ioc;
using FlightFinder.App.ViewModels;
using FlightFinder.App.Views;
using FlightFinder.Common.Services;
using FlightFinder.Shared.Services;
using FlightFinder.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FlightFinder.App
{
    public partial class App
    {   
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            LiveReload.Init();

            await NavigationService.NavigateAsync("NavigationPage/FlightSearchPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<FlightSearchPage, FlightSearchPageViewModel>();

            // Services
            containerRegistry.RegisterSingleton<FlightSearchState>();
            containerRegistry.Register<IAppConfiguration, AppConfiguration>();
            containerRegistry.Register<IFlightSearchService, FlightSearchService>();
        }
    }
}
