using Develab.Enum;
using Develab.Helpers;
using Develab.Views;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Develab
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override async void OnStart()
        {
            var loginData = await SecureStorage.GetAsync(SecureStorageConstants.LoginData);
            if (string.IsNullOrEmpty(loginData))
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainPage = new AppShell();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
