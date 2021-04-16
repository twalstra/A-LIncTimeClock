using System;
using TimeTrackerTutorial.Droid.Services;
using TimeTrackerTutorial.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(BreakRepository))]
namespace TimeTrackerTutorial.Droid.Services
{
    public class BreakRepository : BaseRepository<BreakItem>
    {
        protected override string DocumentPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/breaks";
    }
}
