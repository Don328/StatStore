using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Services.Interfaces;

namespace StatStore.Loader.Core
{
    public class RequestQueue : BackgroundService, IDisposable, IQueueRequests
    {
        private readonly CancellationTokenSource tokenSource;
        private readonly ILogger<RequestQueue> logger;
        private readonly ILoadState stateLoader;

        public RequestQueue(
            ILogger<RequestQueue> logger,
            ILoadState stateLoader)
        {
            tokenSource = new();
            this.logger = logger;
            this.stateLoader = stateLoader;
        }

        public async Task StartAsync()
        {
            logger.LogInformation("Request queue starting.");
            await ExecuteAsync(tokenSource.Token);
            Dispose();
        }

        public async Task StopAsync()
        {
            logger.LogInformation("Stopping request queue.");
            tokenSource.Cancel();
            await Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await stateLoader.Initialize();

                // Do work

                // Adding a 30 second sleep in between iterations of the program cycle
                // This should be removed once the request queue is active
                //
                // The request queue should handle the [Thead.Sleep] call
                // according to the time of the next request in the queue.
                logger.LogInformation("Cycle complete. Thread sleeping for 30 seconds.");
                Thread.Sleep(30000);
            }

            await Task.CompletedTask;
        }

        public override void Dispose()
        {
            tokenSource.Dispose();
            base.Dispose();
        }
    }
}
