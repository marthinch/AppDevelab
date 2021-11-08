using Develab.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Develab.Interfaces
{
    public interface IWebApi
    {
        [Get("/reverse?format=json&lat={latitude}&lon={longitude}")]
        Task<Country> GetCountry([Query] double latitude, double longitude);

        [Get("/country/{countryName}?from={fromDate}&to={toDate}")]
        Task<List<Case>> GetCases([Query] string countryName, string fromDate, string toDate);
    }
}
