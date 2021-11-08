using Develab.Models;
using Develab.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Develab.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardDetailPage : ContentPage
    {
        public DashboardDetailPage(Case caseDetail)
        {
            InitializeComponent();

            BindingContext = new DashboardDetailViewModel(caseDetail);
        }
    }
}