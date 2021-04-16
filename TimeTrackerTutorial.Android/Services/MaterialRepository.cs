using System;
using TimeTrackerTutorial.Models;

namespace TimeTrackerTutorial.Droid.Services
{
    public class MaterialRepository : BaseRepository<MaterialItem>
    {
        protected override string DocumentPath => throw new NotImplementedException();
    }
}
