using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Models;
using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader.Core
{
    public class AppState
    {
        public AppState()
        {
            TimeFrame = new();
            LoadRecord = new();
            RequestQueue = new();
        }

        public List<ScheduledRequest.Queued> TodaysRequests { get; set; }
        public Queue<ScheduledRequest.Queued> RequestQueue { get; set; }
        public TimeFrame TimeFrame { get; set; }
        public LoadRecord LoadRecord { get; set; }
    }
}
