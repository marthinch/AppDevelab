using Develab.Helpers;
using Develab.Interfaces;
using Develab.Models;
using Develab.Views;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Develab.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private ObservableCollection<Case> cases = new ObservableCollection<Case>();
        public ObservableCollection<Case> Cases
        {
            get => cases;
            set => SetProperty(ref cases, value);
        }

        private Case caseDetail;
        public Case CaseDetail
        {
            get => caseDetail;
            set
            {
                if (SetProperty(ref caseDetail, value) && value != null)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new DashboardDetailPage(CaseDetail));
                    });
                }
            }
        }

        private string country;
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        private DateTime dateFrom;
        public DateTime DateFrom
        {
            get => dateFrom;
            set => SetProperty(ref dateFrom, value);
        }

        private DateTime dateTo;
        public DateTime DateTo
        {
            get => dateTo;
            set => SetProperty(ref dateTo, value);
        }

        public DashboardViewModel()
        {
            DateFrom = DateTime.Now.AddDays(-7);
            DateTo = DateFrom.AddDays(7);
        }

        private async Task GetCountryAsync()
        {
            try
            {
                var currentLocation = await LocationHelper.GetCurrentLocation().ConfigureAwait(false);
                if (currentLocation == null)
                    return;

                HttpClient httpClient = new HttpClient(DependencyService.Get<ICustomHttpClientHandler>().GetHttpClientHandler())
                {
                    BaseAddress = new Uri(Enum.Configuration.CountryApiUrl)
                };
                var apiResponse = RestService.For<IWebApi>(httpClient);
                var currentCountry = await apiResponse.GetCountry(currentLocation.Latitude, currentLocation.Longitude).ConfigureAwait(false);

                Country = currentCountry?.address.country;
            }
            catch (Exception exception)
            {

            }
        }

        public async Task LoadCasesAsync()
        {
            if (IsLoading)
                return;

            try
            {
                IsLoading = true;

                await GetCountryAsync().ConfigureAwait(false);

                Cases.Clear();

                HttpClient httpClient = new HttpClient(DependencyService.Get<ICustomHttpClientHandler>().GetHttpClientHandler())
                {
                    BaseAddress = new Uri(Enum.Configuration.CovidApiUrl)
                };
                var apiResponse = RestService.For<IWebApi>(httpClient);

                string from = DateFrom.ToString("yyyy-MM-dd");
                string to = DateTo.ToString("yyyy-MM-dd");

                var listCase = await apiResponse.GetCases(Country, from, to).ConfigureAwait(false);
                if (listCase.Capacity == 0)
                    return;

                // Filter by date
                listCase = listCase.Where(a => a.Date.Date >= dateFrom.Date && a.Date.Date <= dateTo.Date).ToList();
                if (listCase.Capacity == 0)
                    return;

                foreach (var item in listCase)
                    Cases.Add(item);
            }
            catch (Exception exception)
            {

            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
