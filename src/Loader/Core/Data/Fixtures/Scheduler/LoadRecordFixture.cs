using StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Fixtures.Scheduler
{
    /// <summary>
    /// Database access for LoadRecord table
    /// A seed row is created on initial run with all load times set to DateTime.Min and Id = 1
    /// There is only one row in the LoadRecord table (Id=1)
    /// The Get method always returns Id=1
    /// There is no Add method
    /// The Update method only operates on Id=1
    /// </summary>
    public class LoadRecordFixture : ILoadRecordFixture
    {
        private readonly ILogger<LoadRecordFixture> logger;
        private readonly AppScheduleContext db;

        public LoadRecordFixture(
            ILogger<LoadRecordFixture> logger,
            AppScheduleContext db)
        {
            this.logger = logger;
            this.db = db;
        }
        
        /// <summary>
        /// Gets the LoadRecord where Id = 1
        /// </summary>
        /// <returns>LoadRecord</returns>

        public async Task<LoadRecord> Get()
        {
            var record = (from r in db.LoadRecord
                          where r.Id == 1
                          select r).First();

            logger.LogInformation("Returning LoadRecord from database");
            return await Task.FromResult(record);
        }

        /// <summary>
        /// Replaces LoadRecord(Id=1) with input LoadRecord
        /// Updates LastUpdate value of LoadRecord to current DateTime.Now
        /// </summary>
        /// <param name="record">
        /// A LoadRecord object with updated load dates
        /// This LoadRecord object should come form state.LoadRecord and have the value to update applied
        /// </param>
        /// <returns>The updated LoadRecord</returns>
        public async Task Update(LoadRecord record)
        {
            logger.LogInformation("Updating load record");

            record.Id = 1;
            record.LastUpdate = DateTime.Now;
            db.Update(record);
            await db.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
