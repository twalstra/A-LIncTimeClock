using System;
using System.Threading.Tasks;

namespace TimeTrackerTutorial.Services.Dialog
{
    public class AlertService : IAlertService
    {
        public AlertService()
        {
        }

        public Task<bool> AlertAsync(string title, string message, string confirm, string cancel)
        {
            return App.Current.MainPage.DisplayAlert(title, message, confirm, cancel);
        }

        public Task AlertAsync(string title, string message, string confirm)
        {
            return App.Current.MainPage.DisplayAlert(title, message, confirm);
        }
    }
}
