using System;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services;
using TimeTrackerTutorial.ViewModels.Buttons;

namespace TimeTrackerTutorial.PageModels
{
    public class RecentActivityPageModel : PageModelBase
    {

        private ButtonModel _viewAllModel;
        public ButtonModel ViewAllModel
        {
            get => _viewAllModel;
            set => SetProperty(ref _viewAllModel, value);
        }

        private ButtonModel _clockInModel;
        public ButtonModel ClockInModel
        {
            get => _clockInModel;
            set => SetProperty(ref _clockInModel, value);
        }

        private IRepository<TestData> _jobsRepository;

        public RecentActivityPageModel(IRepository<TestData> jobsRepository)
        {
            _jobsRepository = jobsRepository;

            ViewAllModel = new ButtonModel("View All", OnViewAll);
            ClockInModel = new ButtonModel("CLOCK IN", OnClockIn);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);

        }

        private async void OnClockIn()
        {
            var jobs = await _jobsRepository.GetAll();

        }

        private void OnViewAll()
        {

        }
    }
}
