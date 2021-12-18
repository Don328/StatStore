using StatStore.Loader.Core.Interfaces;

namespace StatStore.Loader.Core
{
    public class RequestQueue : BackgroundService, IDisposable, IRequestQueue
    {
        private readonly CancellationTokenSource tokenSource;
        private readonly ILogger<RequestQueue> logger;

        public RequestQueue(ILogger<RequestQueue> logger)
        {
            tokenSource = new();

            this.logger = logger;
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
                // Load daily Schedule

                // Do Work
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
