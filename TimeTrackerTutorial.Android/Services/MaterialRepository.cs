using System;
using TimeTrackerTutorial.Droid.Services;
using TimeTrackerTutorial.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(MaterialRepository))]
namespace TimeTrackerTutorial.Droid.Services
{
    public class MaterialRepository : BaseRepository<MaterialItem>
    {
        protected override string DocumentPath =>
            "users/"
            + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
            + "/materials";
    }
}
