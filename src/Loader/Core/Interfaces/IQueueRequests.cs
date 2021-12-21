namespace StatStore.Loader.Core.Interfaces
{
    public interface IQueueRequests
    {
        void Dispose();
        Task StartAsync();
        Task StopAsync();
    }
}