using Develab.Enum;
using Develab.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Develab.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public ICommand RemoveUserCommand => new Command(async () => await RemoveUserAsync());

        private Login login = new Login();
        public Login Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        public AccountViewModel()
        {

        }

        public async Task GetCurrentUserAsync()
        {
            var loginData = await SecureStorage.GetAsync(SecureStorageConstants.LoginData);
            if (string.IsNullOrEmpty(loginData))
                return;

            Login = JsonConvert.DeserializeObject<Login>(loginData);
        }

        private async Task RemoveUserAsync()
        {
            // Remove login data from local storage
            SecureStorage.Remove(SecureStorageConstants.LoginData);

            await Application.Current.MainPage.DisplayAlert(string.Empty, "User is removed", "OK");
        }
    }
}
