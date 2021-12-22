using StatStore.Loader.Core.Data.Fixtures.SportsDataIO.Interfaces;
using StatStore.Loader.Core.Data.Loaders.DataLoaders.Interfaces;
using StatStore.Loader.SportsDataIO.Endpoints.Interfaces;
using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader.Core.Data.Loaders.DataLoaders
{
    public class TimeFrameLoader : ILoadTimeFrame
    {
        private readonly ILogger<TimeFrameLoader> logger;
        private readonly ITimeFrameFixture fixture;
        private readonly IFetchTimeFrame endpoint;

        public TimeFrameLoader(
            ILogger<TimeFrameLoader> logger,
            ITimeFrameFixture fixture,
            IFetchTimeFrame endpoint)
        {
            this.logger = logger;
            this.fixture = fixture;
            this.endpoint = endpoint;
        }

        public async Task<TimeFrame> Get()
        {
            var timeframe = await fixture.Get();
            return await Task.FromResult(timeframe);
        }

        public bool IsStale(TimeFrame timeframe)
        {
            if (timeframe.StartDate is null ||
                timeframe.EndDate < DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TimeFrame> Load()
        {
            var timeframe = await endpoint.Fetch();
            await fixture.Update(timeframe);
            return await Task.FromResult(timeframe);
        }

        public async Task<TimeFrame> ReloadIfStale()
        {
            var timeframe = await Get();
            if (IsStale(timeframe))
            {
                timeframe = await Load();
            }

            return await Task.FromResult(timeframe);
        }
    }
}
