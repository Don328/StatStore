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
            var record = await fixture.Get();
            record.LastLoad = DateTime.Now;
            return record;
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
            record.TimeFrameLoaded = DateTime.Now;
            await fixture.Update(record);
        }
    }
}
