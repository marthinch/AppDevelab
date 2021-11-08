using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Develab.Helpers
{
    public class LocationHelper
    {
        public static async Task<Location> GetCurrentLocation()
        {
            Location currentLocation = null;

            try
            {
                currentLocation = await Geolocation.GetLastKnownLocationAsync().ConfigureAwait(false);
                if (currentLocation == null)
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                    currentLocation = await Geolocation.GetLocationAsync(request).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {

            }

            return currentLocation;
        }
    }
}
