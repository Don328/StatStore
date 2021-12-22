using StatStore.Loader.Core.Data.Fixtures.SportsDataIO.Interfaces;
using StatStore.Shared.SportsDataIO.Models;

namespace StatStore.Loader.Core.Data.Fixtures.SportsDataIO
{
    public class TimeFrameFixture : ITimeFrameFixture
    {
        /// <summary>
        /// Database Access for TimeFrame table
        /// There is only one row in the TimeFrame table (Id=1)
        /// The Get() method ALWAYS returns Id=1
        /// There is no Add method
        /// The Update() method ONLY operates on Id=1
        /// </summary>
        private readonly ILogger<TimeFrameFixture> logger;
        private readonly AppDataContext db;

        public TimeFrameFixture(
            ILogger<TimeFrameFixture> logger,
            AppDataContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        /// <summary>
        /// Gets the TimeFrame where Id = 1
        /// </summary>
        /// <returns>TimeFrame</returns>
        public async Task<TimeFrame> Get()
        {
            var timeFrame = (from t in db.CurrentTimeFrame
                      where t.Id == 1
                      select t).First();

            logger.LogInformation($"Returning TimeFrame from database. Season: {timeFrame.Season} : {timeFrame.SeasonType} Week: {timeFrame.Week}"); ;
            return await Task.FromResult(timeFrame);
        }

        /// <summary>
        /// Replaces TimeFrame(Id=1) with input TimeFrame
        /// </summary>
        /// <param name="timeframe">
        /// This object should come from a call to the SportsDataIO api
        /// </param>
        /// <returns>The updated TimeFrame</returns>
        public async Task Update(TimeFrame timeframe)
        {
            logger.LogInformation("Updating TimeFrame");
            timeframe.Id = 1;
            db.Update(timeframe);
            await db.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
