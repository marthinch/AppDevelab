using Develab.Droid.Implementations;
using Develab.Interfaces;
using System.Net.Http;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomHTTPClientHandler))]
namespace Develab.Droid.Implementations
{
    public class CustomHTTPClientHandler : ICustomHttpClientHandler
    {
        public HttpClientHandler GetHttpClientHandler()
        {
            return new Xamarin.Android.Net.AndroidClientHandler();
        }
    }
}