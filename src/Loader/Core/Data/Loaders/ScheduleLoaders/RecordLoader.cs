using StatStore.Loader.Core.Data.Fixtures.Scheduler;
using StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces;
using StatStore.Loader.Core.Data.Loaders.ScheduleLoaders.Interfaces;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Loaders.ScheduleLoaders
{
    public class RecordLoader : ILoadRecords
    {
        private readonly ILogger<RecordLoader> logger;
        private readonly ILoadRecordFixture fixture;

        public RecordLoader(
            ILogger<RecordLoader> logger,
            ILoadRecordFixture fixture)
        {
            this.logger = logger;
            this.fixture = fixture;
        }

        public async Task<LoadRecord> GetRecord()
        {
            logger.LogInformation("Getting load record from database.");
            var record = await fixture.Get();
            logger.LogInformation($"last load: {record.LastLoad}");
            record.LastLoad = DateTime.Now;
            await fixture.Update(record);
            logger.LogInformation($"loaded: {record.LastLoad}");
            return await Task.FromResult(record);
        }

        public bool LoadedToday(LoadRecord record)
        {
            if (record.LastLoad.Date == DateTime.Now.Date)
                return true;
            else
                return false;
        }

        public async Task TimeFrameLoaded(LoadRecord record)
        {
            logger.LogInformation("Recording TimeFrame load in load record.");
            record.TimeFrameLoaded = DateTime.Now;
            await fixture.Update(record);
            await Task.CompletedTask;
        }

        public async Task QueueLoaded(LoadRecord record)
        {
            logger.LogInformation("Recording Queue load in load record.");
            record.QueueLoaded = DateTime.Now;
            await fixture.Update(record);
            await Task.CompletedTask;
        }
    }
}
