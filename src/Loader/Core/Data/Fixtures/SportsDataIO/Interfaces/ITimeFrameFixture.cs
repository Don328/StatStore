using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader.Core.Data.Fixtures.SportsDataIO.Interfaces
{
    public interface ITimeFrameFixture
    {
        Task<TimeFrame> Get();
        Task Save(TimeFrame timeframe);
    }
}
