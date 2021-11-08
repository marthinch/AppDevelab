using Develab.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Develab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        private readonly AccountViewModel accountViewModel;

        public AccountPage()
        {
            InitializeComponent();

            BindingContext = accountViewModel = new AccountViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await accountViewModel.GetCurrentUserAsync();
        }
    }
}