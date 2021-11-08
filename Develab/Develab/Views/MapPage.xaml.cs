using Develab.Helpers;
using Develab.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Develab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private readonly MapViewModel mapViewModel;

        public MapPage()
        {
            InitializeComponent();

            BindingContext = mapViewModel = new MapViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var currentLocation = await LocationHelper.GetCurrentLocation().ConfigureAwait(false);
            if (currentLocation == null)
                return;

            mapViewModel.Latitude = currentLocation.Latitude;
            mapViewModel.Longitude = currentLocation.Longitude;

            Device.BeginInvokeOnMainThread(() =>
            {
                Position position = new Position(currentLocation.Latitude, currentLocation.Longitude);
                Map.MoveToRegion(MapSpan.FromCenterAndRadius(position, new Distance(1)));
                Map.Pins.Add(new Pin
                {
                    Label = "Your Current Location",
                    Position = position
                });
            });
        }
    }
}