using StatStore.Loader.Core.Data.Fixtures.Scheduler.Interfaces;
using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Fixtures.Scheduler
{
    public class RequestQueueFixture : IRequestQueueFixture
    {
        /// <summary>
        /// Database access for Queued requests
        /// Requests are queued daily
        /// </summary>

        private readonly ILogger<RequestQueueFixture> logger;
        private readonly AppScheduleContext db;

        public RequestQueueFixture(
            ILogger<RequestQueueFixture> logger,
            AppScheduleContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        /// <summary>
        /// Gets all requests for DateTime.Today
        /// </summary>
        /// <returns>A list of Queued ScheduledRequests</returns>
        public async Task<List<ScheduledRequest.Queued>> Get()
        {
            var requests = (
                from r in db.QueuedRequests
                where r.ScheduledAt.Date == DateTime.Today
                orderby r.ExecuteAt
                select r).ToList();

            return await Task.FromResult(requests);
        }

        /// <summary>
        /// Updates a request
        /// Ususally to update the IsCompleted and CompletedAt values
        /// </summary>
        /// <param name="request">
        ///     The request to be updated
        /// </param>
        /// <returns>Task</returns>
        public async Task Update(ScheduledRequest.Queued request)
        {
            db.Update(request);
            await db.SaveChangesAsync();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Adds a request to the saved queue
        /// </summary>
        /// <param name="request">
        /// The request to add
        /// </param>
        /// <returns>Task</returns>
        public async Task Add(ScheduledRequest.Queued request)
        {
            db.Add(request);
            await db.SaveChangesAsync();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Removes a request from the queue
        /// </summary>
        /// <param name="request">The requst to remove</param>
        /// <returns>Task</returns>
        public async Task Remove(ScheduledRequest.Queued request)
        {
            db.Remove(request);
            await db.SaveChangesAsync();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Saves a list of Queued ScheduedRequests
        /// Performed to load the daily request queue
        /// </summary>
        /// <param name="requests">
        /// The requsts to add
        /// </param>
        /// <returns>Task</returns>
        public async Task Save(List<ScheduledRequest.Queued> requests)
        {
            foreach (var r in requests)
            {
                r.Id = 0;
                db.QueuedRequests.Add(r);
            }

            await db.SaveChangesAsync();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Reads ScheduledRequests and gets all requests that
        /// should be executed on DateTime.Today
        /// 
        /// Calls the Save() method to save the various ScheduledRequest
        /// objects as ScheduledRequest.Queued objects
        /// </summary>
        /// <returns>Task</returns>
        public async Task Load()
        {
            var requests = new List<ScheduledRequest.Queued>();
            var annual = await GetAnnualRequestsToQueue();
            var daily = await GetDailyRequestsToQueue();
            var monthly = await GetMonthlyRequestsToQueue();
            var oneoff = await GetOneoffRequestsToQueue();
            var oneoffSpan = await GetOneoffSpanRequestsToQueue();
            var weekly = await GetWeeklyRequestsToQueue();
            var weeklySpan = await GetWeeklySpanRequestsToQueue();
            
            requests.AddRange(annual);
            requests.AddRange(daily);
            requests.AddRange(monthly);
            requests.AddRange(oneoff);
            requests.AddRange(oneoffSpan);
            requests.AddRange(weekly);
            requests.AddRange(weeklySpan);
            
            requests.OrderBy(r => r.ExecuteAt);

            await Save(requests);
            await Task.CompletedTask;
        }

        private async Task<List<ScheduledRequest.Queued>> GetAnnualRequestsToQueue()
        {
            var requestsToQueue = new List<ScheduledRequest.Queued>();
            var set = db.Set<ScheduledRequest.Annual>();
            var requests = (
                from r in set
                where r.DayOfMonth == DateTime.Today.Day
                && r.Month == DateTime.Today.Month
                select r).ToList();

            foreach (var request in requests)
            {
                requestsToQueue.Add(
                    new ScheduledRequest
                        .Queued(request));
            }

            return await Task.FromResult(requestsToQueue);
        }

        private async Task<List<ScheduledRequest.Queued>> GetDailyRequestsToQueue()
        {
            var requestsToQueue = new List<ScheduledRequest.Queued>();
            var set = db.Set<ScheduledRequest.Daily>();
            var requests = (
                from r in set
                select r).ToList();

            foreach (var request in requests)
            {
                requestsToQueue.Add(
                    new ScheduledRequest
                        .Queued(request));
            }

            return await Task.FromResult(requestsToQueue);
        }

        private async Task<List<ScheduledRequest.Queued>> GetMonthlyRequestsToQueue()
        {
            var requestsToQueue = new List<ScheduledRequest.Queued>();

            var set = db.Set<ScheduledRequest.Monthly>();
            var requests = (
                from r in set
                where r.DayOfMonth == DateTime.Today.Day
                select r).ToList();

            foreach (var request in requests)
            {
                requestsToQueue.Add(
                    new ScheduledRequest
                        .Queued(request));
            }

            return await Task.FromResult(requestsToQueue);
        }

        private async Task<List<ScheduledRequest.Queued>> GetOneoffRequestsToQueue()
        {
            var requestsToQueue = new List<ScheduledRequest.Queued>();
            var set = db.Set<ScheduledRequest.Oneoff>();
            var requests = (
                from r in set
                where r.Date == DateTime.Today
                select r).ToList();

            foreach (var request in requests)
            {
                requestsToQueue.Add(
                    new ScheduledRequest
                        .Queued(request));
            }

            return await Task.FromResult(requestsToQueue);
        }

        private async Task<List<ScheduledRequest.Queued>> GetOneoffSpanRequestsToQueue()
        {
            var requestsToQueue = new List<ScheduledRequest.Queued>();
            var set = db.Set<ScheduledRequest.OneoffSpan>();
            var spanSet = (
                from s in set
                where s.Date == DateTime.Today
                select s).ToList();

            foreach (var span in spanSet)
            {
                var expandedSet = await RequestSpanExpander.Unpack(span);
                requestsToQueue.AddRange(expandedSet);
            }

            return await Task.FromResult(requestsToQueue);
        }

        private async Task<List<ScheduledRequest.Queued>> GetWeeklyRequestsToQueue()
        {
            var requestsToQueue = new List<ScheduledRequest.Queued>();
            var set = db.Set<ScheduledRequest.Weekly>();
            var requests = (
                from r in set
                where r.Day == DateTime.Today.DayOfWeek
                select r).ToList();

            foreach (var request in requests)
            {
                requestsToQueue.Add(
                    new ScheduledRequest
                        .Queued(request));
            }

            return await Task.FromResult(requestsToQueue);
        }

        private async Task<List<ScheduledRequest.Queued>> GetWeeklySpanRequestsToQueue()
        {
            var requestsToQueue = new List<ScheduledRequest.Queued>();
            var set = db.Set<ScheduledRequest.WeeklySpan>();
            var spanSet = (
                from s in set
                where s.Day == DateTime.Today.DayOfWeek
                select s).ToList();

            foreach (var span in spanSet)
            {
                var expandedSet = await RequestSpanExpander.Unpack(span);
                requestsToQueue.AddRange(expandedSet);
            }

            return await Task.FromResult(requestsToQueue);
        }
    }
}
