using StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces;
using StatStore.Loader.Core.Data.Loaders.DataLoaders.Interfaces;
using StatStore.Loader.Core.Data.Loaders.ScheduleLoaders.Interfaces;
using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Models;
using StatStore.Loader.Core.Services.Interfaces;

namespace StatStore.Loader.Core.Services
{
    public class StateLoader : ILoadState
    {
        private readonly ILogger<StateLoader> logger;
        private readonly AppState state;
        private readonly ILoadRecords recordLoader;
        private readonly ILoadTimeFrame timeFrameLoader;
        private readonly IRequestQueueFixture queueFixture;

        public StateLoader(
            ILogger<StateLoader> logger,
            AppState state,
            ILoadRecords recordLoader,
            ILoadTimeFrame timeFrameLoader,
            IRequestQueueFixture queuefixture)
        {
            this.logger = logger;
            this.state = state;
            this.recordLoader = recordLoader;
            this.timeFrameLoader = timeFrameLoader;
            this.queueFixture = queuefixture;
        }

        public AppState State { get => state; }

        public async Task Initialize()
        {
            logger.LogInformation("Initialiazing state");
            state.LoadRecord = await recordLoader.GetRecord();
            await GetCurrentTimeFrame();
            await LoadRequestQueue();
            await Task.CompletedTask;
        }

        private async Task GetCurrentTimeFrame()
        {
            logger.LogInformation("Getting Current Time Frame.");
            if (state.LoadRecord.TimeFrameLoaded.Date < DateTime.Today)
            {
                logger.LogInformation("Timeframe is stale. Loading...");
                state.TimeFrame = await timeFrameLoader.Load();
                await recordLoader.TimeFrameLoaded(state.LoadRecord);
                state.LoadRecord = await recordLoader.GetRecord();
            }
            else
            {
                logger.LogInformation($"TimeFrame last load: {state.LoadRecord.TimeFrameLoaded} | Getting from database");
                state.TimeFrame = await timeFrameLoader.Get();
            }

            await Task.CompletedTask;
        }

        private async Task LoadRequestQueue()
        {
            logger.LogInformation("Loading request queue");

            if (state.LoadRecord.QueueLoaded.Date < DateTime.Today)
            {
                logger.LogInformation("Queue has not been loaded. Loading Queue...");
                await queueFixture.Load();
                await recordLoader.QueueLoaded(state.LoadRecord);
            }

            logger.LogInformation("Getting request queue from database.");

            state.TodaysRequests = await queueFixture.Get();
            var requests = (
                from r in state.TodaysRequests
                where r.IsCompleted == false
                orderby r.ExecuteAt
                select r).ToList();

            state.RequestQueue = new Queue<ScheduledRequest.Queued>(requests);
            await Task.CompletedTask;
        }
    }
}
