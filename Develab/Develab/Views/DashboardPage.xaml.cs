using Develab.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Develab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        private readonly DashboardViewModel dashboardViewModel;

        public DashboardPage()
        {
            InitializeComponent();

            BindingContext = dashboardViewModel = new DashboardViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await dashboardViewModel.LoadCasesAsync();
        }
    }
}