using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces
{
    public interface ILoadRecordFixture
    {
        Task<LoadRecord> Get();
        Task Update(LoadRecord record);
    }
}
