using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Fixtures.Scheduler
{
    public class RequestFixture<T> where T : class
    {
        private readonly ILogger<RequestFixture<T>> logger;
        private readonly AppScheduleContext db;

        public RequestFixture(
            ILogger<RequestFixture<T>> logger,
            AppScheduleContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        
    }
}
