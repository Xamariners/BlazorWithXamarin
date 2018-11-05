using FlightFinder.App.Services;
using Prism;
using Prism.Ioc;
using FlightFinder.App.ViewModels;
using FlightFinder.App.Views;
using FlightFinder.Common.Services;
using FlightFinder.Shared.Services;
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

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            // Services
            containerRegistry.Register<IAppConfiguration, AppConfiguration>();
            containerRegistry.Register<IFlightSearchService, FlightSearchService>();
        }
    }
}
