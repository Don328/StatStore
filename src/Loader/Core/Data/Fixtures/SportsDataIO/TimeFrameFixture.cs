using StatStore.Loader.Core.Data.Fixtures.SportsDataIO.Interfaces;
using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader.Core.Data.Fixtures.SportsDataIO
{
    public class TimeFrameFixture : ITimeFrameFixture
    {
        private PayloadRepo<TimeFrame> repo;

        public TimeFrameFixture(
            AppDataContext context)
        {
            repo = new(context);
        }

        public async Task<TimeFrame> Get()
        {
            return await Task.FromResult(
                repo.GetById(1))?? new();
        }

        public async Task Save(TimeFrame timeframe)
        {
            timeframe.Id = 1;
            repo.Update(timeframe);
            await Task.CompletedTask;
        }
    }
}
