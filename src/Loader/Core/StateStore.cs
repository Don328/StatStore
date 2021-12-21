using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Models;
using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader.Core
{
    public class StateStore
    {
        public StateStore()
        {
            TimeFrame = new();
            LoadRecord = new();
            RequestQueue = new();
        }

        public Queue<ScheduledRequest.Queued> RequestQueue { get; set; }
        public TimeFrame TimeFrame { get; set; }
        public LoadRecord LoadRecord { get; set; }
    }
}
