using System;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Droid.Services
{
    public class WorkRepository : BaseRepository<WorkItem>
    {

        protected override string DocumentPath => throw new NotImplementedException();
    }
}
