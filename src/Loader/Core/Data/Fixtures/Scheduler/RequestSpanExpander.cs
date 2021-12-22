using StatStore.Loader.Core.Models;

namespace StatStore.Loader.Core.Data.Fixtures.Scheduler
{
    internal static class RequestSpanExpander
    {
        internal static async Task<List<ScheduledRequest.Queued>> Unpack(ScheduledRequest.OneoffSpan span)
        {
            var queuedRequests = new List<ScheduledRequest.Queued>();
            var executeAt = span.ExecuteAt;

            while (executeAt < span.ExecuteAt + span.Durration)
            {
                var oneoff = new ScheduledRequest.Oneoff
                {
                    Tag = span.Tag,
                    ExecuteAt = executeAt,
                    Month = span.Month,
                    DayOfMonth = span.DayOfMonth,
                    DayOfWeek = span.DayOfWeek,
                };
                
                queuedRequests.Add(new ScheduledRequest.Queued(oneoff));
                executeAt += span.Frequency;
            }

            return await Task.FromResult(queuedRequests);
        }
        
        internal static async Task<List<ScheduledRequest.Queued>> Unpack(ScheduledRequest.WeeklySpan span)
        {
            var queuedRequests = new List<ScheduledRequest.Queued>();
            var executeAt = span.ExecuteAt;

            while (executeAt < span.ExecuteAt + span.Durration)
            {
                var weekly = new ScheduledRequest.Weekly
                {
                    Tag = span.Tag,
                    ExecuteAt = executeAt,
                    Day = span.Day,
                };

                queuedRequests.Add(new ScheduledRequest.Queued(weekly));
                executeAt += span.Frequency;
            }

            return await Task.FromResult(queuedRequests);
        }
    }
}
