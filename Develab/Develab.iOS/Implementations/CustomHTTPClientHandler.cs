using Develab.Interfaces;
using Develab.iOS.Implementations;
using System.Net.Http;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomHTTPClientHandler))]
namespace Develab.iOS.Implementations
{
    public class CustomHTTPClientHandler : ICustomHttpClientHandler
    {
        public HttpClientHandler GetHttpClientHandler()
        {
            return new HttpClientHandler();
        }
    }
}