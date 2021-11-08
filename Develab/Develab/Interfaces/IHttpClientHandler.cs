using System.Net.Http;

namespace Develab.Interfaces
{
    public interface ICustomHttpClientHandler
    {
        HttpClientHandler GetHttpClientHandler();
    }
}
