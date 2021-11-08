namespace Develab.Enum
{
    public static class Configuration
    {
        private const string CountryHostName = "nominatim.openstreetmap.org";
        public static string CountryApiUrl = $"https://{CountryHostName}/";

        private const string CovidHostName = "api.covid19api.com";
        public static string CovidApiUrl = $"https://{CovidHostName}/";
    }
}
