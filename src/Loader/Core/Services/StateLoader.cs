using StatStore.Loader.Core.Data.Loaders.DataLoaders.Interfaces;
using StatStore.Loader.Core.Data.Loaders.ScheduleLoaders.Interfaces;
using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Models;
using StatStore.Loader.Core.Services.Interfaces;

namespace StatStore.Loader.Core.Services
{
    public class StateLoader : IStateLoader
    {
        private readonly ILogger<StateLoader> logger;
        private readonly StateStore state;
        private readonly ILoadRecords recordLoader;
        private readonly ILoadTimeFrame timeFrameLoader;

        public StateLoader(
            ILogger<StateLoader> logger,
            StateStore state,
            ILoadRecords recordLoader,
            ILoadTimeFrame timeFrameLoader)
        {
            this.logger = logger;
            this.state = state;
            this.recordLoader = recordLoader;
            this.timeFrameLoader = timeFrameLoader;
        }

        public StateStore State { get => state; }

        public async Task Initialize()
        {
            state.LoadRecord = await recordLoader.GetRecord();
            await GetCurrentTimeFrame();

            // Get current request queue record from db
            // Evaluate request record
            //     if current record null | stale:
            //         create a new record and save to db
            await Task.CompletedTask;
        }

        private async Task GetCurrentTimeFrame()
        {
            var timeFrame = await timeFrameLoader.ReloadIfStale();
            state.TimeFrame = timeFrame;
            await recordLoader.TimeFrameLoaded(state.LoadRecord);
            state.LoadRecord = await recordLoader.GetRecord();
            await Task.CompletedTask;
        }
    }
}
