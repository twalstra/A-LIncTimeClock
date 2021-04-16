using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackerTutorial.Services;

namespace TimeTrackerTutorial.Models
{
    public class BreakItem : IIdentifiable
    {
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class MaterialItem : IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }

    public class WorkItem : IIdentifiable
    {
        public string JobId { get; set; }
        public string JobName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Total
        {
            get
            {
                // Return End - Start, less any break time.
                var total = End - Start;
                return total;
            }
        }

        public string Id { get; set; }
    }
}
