using StatStore.Loader.Core.Interfaces;
using StatStore.Loader.Core.Models;
using StatStore.Loader.Core.Services.Interfaces;
using static StatStore.Loader.SportsDataIO.Constants;

namespace StatStore.Loader.Core
{
    public class RequestQueue : BackgroundService, IDisposable, IQueueRequests
    {
        private readonly CancellationTokenSource tokenSource;
        private readonly ILogger<RequestQueue> logger;
        private readonly ILoadState stateLoader;
        private readonly AppState state;

        public RequestQueue(
            ILogger<RequestQueue> logger,
            ILoadState stateLoader,
            AppState state)
        {
            tokenSource = new();
            this.logger = logger;
            this.stateLoader = stateLoader;
            this.state = state;
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

                while (state.RequestQueue.Peek() != null)
                {
                    var next = state.RequestQueue.Peek();
                    if (next.ExecuteAt > DateTime.Now.TimeOfDay)
                    {
                        logger.LogInformation($"Waiting for next queued request: {next.Tag} Execute at: {next.ExecuteAt}");
                        var offset = next.ExecuteAt = DateTime.Now.TimeOfDay;
                        Thread.Sleep(offset);
                    }

                    await IssueNextRequest();
                }

                logger.LogInformation("Request queue is empty. Thread is sleeping until tomorrow");
                var timeToTomorrow = new TimeSpan(11, 59, 59) - DateTime.Now.TimeOfDay;
                Thread.Sleep(timeToTomorrow);
            }

            await Task.CompletedTask;
        }

        public override void Dispose()
        {
            tokenSource.Dispose();
            base.Dispose();
        }

        private async Task IssueNextRequest()
        {
            var request = state.RequestQueue.Dequeue();
            var season = state.TimeFrame.Season??0;
            var week = state.TimeFrame.Week??0;

            switch (request.Tag)
            {
                case RequestTag.scoresByWeek:

                    break;
            }


            await Task.CompletedTask;
        }
    }
}
