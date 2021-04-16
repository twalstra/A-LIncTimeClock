using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services;
using TimeTrackerTutorial.Services.Dialog;
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

        private IList<JobItem> _jobs;
        public IList<JobItem> Jobs
        {
            get => _jobs;
            set => SetProperty(ref _jobs, value);
        }

        private ObservableCollection<WorkItem> _work;
        public ObservableCollection<WorkItem> Work
        {
            get => _work;
            set => SetProperty(ref _work, value);
        }

        private JobItem _selectedJob;
        public JobItem SelectedJob
        {
            get => _selectedJob;
            set => SetProperty(ref _selectedJob, value);
        }

        private IRepository<JobItem> _jobsRepository;
        private IRepository<WorkItem> _workRepository;
        private IAlertService _alertService;

        public RecentActivityPageModel(IRepository<JobItem> jobsRepository,
            IRepository<WorkItem> workRepo, IAlertService alertService)
        {
            _jobsRepository = jobsRepository;
            _workRepository = workRepo;
            _alertService = alertService;

            ViewAllModel = new ButtonModel("View All", OnViewAll);
            ClockInModel = new ButtonModel("CLOCK IN", OnClockIn);
        }


        public override async Task InitializeAsync(object navigationData)
        {
            Jobs = await _jobsRepository.GetAll();
            Work = new ObservableCollection<WorkItem>(await _workRepository.GetAll());

            await base.InitializeAsync(navigationData);

        }

        private bool _isClockedIn = false;
        private DateTime _start;
        private async void OnClockIn()
        {
            if (SelectedJob == null)
            {
                // warn user
                await _alertService.AlertAsync("Uh oh...", "Select a job to clock in.", "Ok");
                return;
            }
            if (_isClockedIn)
            {
                ClockInModel.IsEnabled = false;
                // clock out stuff
                ClockInModel.Text = "CLOCK IN";
                // log this in firestore
                var workItem = new WorkItem
                {
                    Start = _start,
                    End = DateTime.Now,
                    JobId = SelectedJob.Id,
                    JobName = SelectedJob.Name
                };
                var id = await _workRepository.Save(workItem);
                workItem.Id = id;
                Work.Insert(0, workItem);
                ClockInModel.IsEnabled = true;
            }
            else
            {
                // clock in stuff
                ClockInModel.Text = "CLOCK OUT";
                _start = DateTime.Now;
            }
            _isClockedIn = !_isClockedIn;
        }

        private void OnViewAll()
        {

        }
    }
}
