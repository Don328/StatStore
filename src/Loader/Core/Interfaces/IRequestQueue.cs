namespace StatStore.Loader.Core.Interfaces
{
    public interface IRequestQueue
    {
        void Dispose();
        Task StartAsync();
        Task StopAsync();
    }
}