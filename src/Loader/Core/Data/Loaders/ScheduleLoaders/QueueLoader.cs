namespace StatStore.Loader.Core.Data.Loaders.ScheduleLoaders
{
    public class QueueLoader
    {
        private readonly ILogger<QueueLoader> logger;


        public QueueLoader(
            ILogger<QueueLoader> logger)
        {
            this.logger = logger;
        }
    }
}
