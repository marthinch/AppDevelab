using Develab.Models;

namespace Develab.ViewModels
{
    public class DashboardDetailViewModel : BaseViewModel
    {
        private Case caseDetail;
        public Case CaseDetail
        {
            get => caseDetail;
            set => SetProperty(ref caseDetail, value);
        }

        public DashboardDetailViewModel(Case caseDetail)
        {
            CaseDetail = caseDetail;
        }
    }
}
