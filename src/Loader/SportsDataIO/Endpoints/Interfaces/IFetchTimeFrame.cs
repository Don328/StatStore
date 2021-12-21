using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader.SportsDataIO.Endpoints.Interfaces
{
    public interface IFetchTimeFrame
    {
        Task<TimeFrame> Fetch();
    }
}
