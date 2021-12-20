using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Services
{
    public class StateLoader
    {
        private readonly ILogger<StateLoader> logger;
        private readonly StateStore state;

        public StateLoader(ILogger<StateLoader> logger)
        {
            this.logger = logger;
            state = new();
        }

        public StateStore State { get => state; }

        public async Task Initialize()
        {
            state.LoadRecord = new RequestQueueLoadRecord(); ;
            // Get current request queue record from db
            // Evaluate request record
            //     if current record null | stale:
            //         create a new record and save to db
            await Task.CompletedTask;
        }
    }
}
