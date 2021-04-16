using System;
using TimeTrackerTutorial.Droid.Services;
using TimeTrackerTutorial.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(WorkRepository))]
namespace TimeTrackerTutorial.Droid.Services
{
    public class WorkRepository : BaseRepository<WorkItem>
    {

        protected override string DocumentPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/work";
    }
}
