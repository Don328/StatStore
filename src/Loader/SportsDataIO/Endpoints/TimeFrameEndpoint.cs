using StatStore.Loader.SportsDataIO.Endpoints.Interfaces;
using StatStore.Loader.SportsDataIO.Interfaces;
using StatStore.Shared.SportsDataIO.Models;
using static StatStore.Loader.SportsDataIO.Constants;

namespace StatStore.Loader.SportsDataIO.Endpoints
{
    public class TimeFrameEndpoint : IFetchTimeFrame
    {
        private readonly ILogger<TimeFrameEndpoint> logger;
        private readonly HttpClient client;

        public TimeFrameEndpoint(
            ILogger<TimeFrameEndpoint> logger,
            ICustomHttpClient sportsData)
        {
            this.logger = logger;
            client = sportsData.Client;
        }

        public async Task<TimeFrame> Fetch()
        {
            logger.LogInformation("Fetching current timeframe");
            var data = await client.GetAsync(
                $"{sportsDataIOBaseUrl}/{RouteTag.scores}/{RequestTag.timeframe}/current");
            if (!data.IsSuccessStatusCode)
            {
                logger.LogWarning("There was a problem fetching " +
                    "the current timeframe from the SportsDataIO" +
                    "server.");
                return await Task.FromResult<TimeFrame>(new());
            }

            var result = await data.Content
                .ReadFromJsonAsync<List<TimeFrame>>();

            TimeFrame timeframe = result?[0] ?? new();
            if (timeframe.Week != null)
            {
                timeframe.Id = 1;
            }

            logger.LogInformation($"Current TimeFrame fetched from SportsData server. Current season: {timeframe.Season} : {timeframe.SeasonType} week: {timeframe.Week}");

            return await Task.FromResult(timeframe);
        }
    }
}
