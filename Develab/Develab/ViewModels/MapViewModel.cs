namespace Develab.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private double longitude;
        public double Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }

        private double latitude;
        public double Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }

        public MapViewModel()
        {

        }
    }
}
