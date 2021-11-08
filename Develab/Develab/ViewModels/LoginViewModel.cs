using Develab.Enum;
using Develab.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Develab.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand => new Command(async () => await LoginAsync());

        private Login login = new Login();
        public Login Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        public LoginViewModel()
        {

        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrEmpty(Login.Name))
            {
                await Application.Current.MainPage.DisplayAlert(string.Empty, "Name is required", "OK");
                return;
            }

            if (!Login.DateOfBirth.HasValue)
            {
                await Application.Current.MainPage.DisplayAlert(string.Empty, "Date of Birth is required", "OK");
                return;
            }

            // Save to local storage
            var loginData = JsonConvert.SerializeObject(Login);
            await SecureStorage.SetAsync(SecureStorageConstants.LoginData, loginData);

            Application.Current.MainPage = new AppShell();
        }
    }
}
