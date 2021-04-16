using System;
using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services.Account;
using TimeTrackerTutorial.Services.Dialog;
using TimeTrackerTutorial.Services.Navigation;
using TimeTrackerTutorial.ViewModels;
using TimeTrackerTutorial.ViewModels.Buttons;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public LoginEntryViewModel EmailEntryViewModel { get; set; }
        public LoginEntryViewModel PasswordEntryViewModel { get; set; }

        public ButtonModel ForgotPasswordModel { get; set; }
        public ButtonModel LogInModel { get; set; }
        public ButtonModel UsePhoneModel { get; set; }

        private IAlertService _alertService;
        private IAccountService _accountService;
        private INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService,
            IAccountService accountService, IAlertService alertService)
        {
            _alertService = alertService;
            _accountService = accountService;
            _navigationService = navigationService;
            EmailEntryViewModel = new LoginEntryViewModel("email", false);
            PasswordEntryViewModel = new LoginEntryViewModel("password", true);

            ForgotPasswordModel = new ButtonModel("forgot password", OnForgotPassword);
            LogInModel = new ButtonModel("LOG IN", OnLogin);
            UsePhoneModel = new ButtonModel("USE PHONE NUMBER", GoToPhoneLogin);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            if (await _accountService.GetUserAsync() != null)
            {
                await _navigationService.NavigateToAsync<RecentActivityPageModel>();
            }
        }

        private async void OnLogin()
        {
            var loginAttempt = await _accountService.LoginAsync(EmailEntryViewModel.Text, PasswordEntryViewModel.Text);
            if (loginAttempt.IsSuccess)
            {
                // navigate to the Dashboard.
                await _navigationService.NavigateToAsync<RecentActivityPageModel>();
            }
            else
            {
                // TODO: Display an Alert for Failure!
                await _alertService.AlertAsync("Error", loginAttempt.ErrorMessage, "Ok");
            }
        }

        private void OnForgotPassword()
        {

        }

        private void GoToPhoneLogin()
        {
            _navigationService.NavigateToAsync<LoginPhonePageModel>();
        }
    }
}
