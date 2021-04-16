using System;
using TimeTrackerTutorial.Droid.Services;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(JobRepository))]
namespace TimeTrackerTutorial.Droid.Services
{
    public class JobRepository : BaseRepository<JobItem>
    {
        protected override string DocumentPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/jobs";
    }
}
