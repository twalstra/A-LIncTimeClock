using System;
using System.Threading.Tasks;

namespace TimeTrackerTutorial.Services.Dialog
{
    public interface IAlertService
    {
        Task AlertAsync(string title, string message, string confirm);

        Task<bool> AlertAsync(string title, string message, string confirm, string cancel);
    }
}
