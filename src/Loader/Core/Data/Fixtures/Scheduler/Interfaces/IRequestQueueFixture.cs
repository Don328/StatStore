using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces
{
    public interface IRequestQueueFixture
    {
        Task Add(ScheduledRequest.Queued request);
        Task<List<ScheduledRequest.Queued>> Get();
        Task Remove(ScheduledRequest.Queued request);
        Task Save(List<ScheduledRequest.Queued> requests);
        Task Update(ScheduledRequest.Queued request);
        Task Load();
    }
}