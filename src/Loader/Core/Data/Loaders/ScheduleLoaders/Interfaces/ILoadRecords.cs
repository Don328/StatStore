using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Loaders.ScheduleLoaders.Interfaces
{
    public interface ILoadRecords
    {
        Task<LoadRecord> GetRecord();
        bool LoadedToday(LoadRecord record);
        Task TimeFrameLoaded(LoadRecord record);
    }
}