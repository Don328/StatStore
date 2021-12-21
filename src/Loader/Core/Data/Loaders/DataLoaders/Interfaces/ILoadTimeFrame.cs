using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader.Core.Data.Loaders.DataLoaders.Interfaces
{
    public interface ILoadTimeFrame
    {
        Task<TimeFrame> Get();
        bool IsStale(TimeFrame timeframe);
        Task<TimeFrame> Load();
        Task<TimeFrame> ReloadIfStale();
    }
}