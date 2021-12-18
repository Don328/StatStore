using StatStore.Loader.Core.Models;
using StatStore.Shared.Local.Models;

namespace StatStore.Loader.Core.Services
{
    public static class RequestDTOFactory
    {
        public static RequestDTO FromScheduledRequest(ScheduledRequest request, Type type)
        {
            return new RequestDTO
            {
                RequestType = type.Name,
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                Team = request.Team,
                TargetId = request.TargetId,
                Week = request.Week,
                Season = request.Season,
                Minutes = request.Minutes,
                Date = request.Date,
            };
        }

        public static RequestDTO FromDailyRequest(ScheduledRequest.Daily request)
        {
            return new RequestDTO
            {
                RequestType = typeof(
                ScheduledRequest.Daily).Name,
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                Team = request.Team,
                TargetId = request.TargetId,
                Week = request.Week,
                Season = request.Season,
                Minutes = request.Minutes,
                Date = request.Date,
            };
        }

        public static RequestDTO FromOneoffRequest(ScheduledRequest.Oneoff request)
        {
            return new RequestDTO
            {
                RequestType = typeof(
                    ScheduledRequest.Oneoff).Name,
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                Team = request.Team,
                TargetId = request.TargetId,
                Week = request.Week,
                Season = request.Season,
                Minutes = request.Minutes,
                Date = request.Date,
                DayOfMonth = request.DayOfMonth,
                Month = request.Month,
                DayOfWeek = request.DayOfWeek,
            };
        }

        public static RequestDTO FromOneoffSpanRequest(ScheduledRequest.OneoffSpan request)
        {
            return new RequestDTO
            {
                RequestType = typeof(
                ScheduledRequest.OneoffSpan).Name,
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                Team = request.Team,
                TargetId = request.TargetId,
                Week = request.Week,
                Season = request.Season,
                Minutes = request.Minutes,
                Date = request.Date,
                DayOfMonth = request.DayOfMonth,
                Month = request.Month,
                DayOfWeek = request.DayOfWeek,
                Frequency = request.Frequency,
                Durration = request.Durration,
            };
        }

        public static RequestDTO FromWeeklyRequest(ScheduledRequest.Weekly request)
        {
            return new RequestDTO
            {
                RequestType = typeof(
                ScheduledRequest.Weekly).Name,
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                Team = request.Team,
                TargetId = request.TargetId,
                Week = request.Week,
                Season = request.Season,
                Minutes = request.Minutes,
                Date = request.Date,
                DayOfWeek = request.Day,
            };
        }

        public static RequestDTO FromWeeklySpanRequest(ScheduledRequest.WeeklySpan request)
        {
            return new RequestDTO
            {
                RequestType = typeof(
                ScheduledRequest.WeeklySpan).Name,
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                Team = request.Team,
                TargetId = request.TargetId,
                Week = request.Week,
                Season = request.Season,
                Minutes = request.Minutes,
                Date = request.Date,
                DayOfWeek = request.Day,
                Frequency = request.Frequency,
                Durration = request.Durration,
            };
        }

        public static RequestDTO FromMonthlyRequst(ScheduledRequest.Monthly request)
        {
            return new RequestDTO
            {
                RequestType = typeof(
                ScheduledRequest.Monthly).Name,
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                Team = request.Team,
                TargetId = request.TargetId,
                Week = request.Week,
                Season = request.Season,
                Minutes = request.Minutes,
                Date = request.Date,
                DayOfMonth = request.DayOfMonth,
            };
        }

        public static RequestDTO FromAnnualRequst(ScheduledRequest.Annual request)
        {
            return new RequestDTO
            {
                RequestType = typeof(
                ScheduledRequest.Annual).Name,
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                Team = request.Team,
                TargetId = request.TargetId,
                Week = request.Week,
                Season = request.Season,
                Minutes = request.Minutes,
                Date = request.Date,
                DayOfMonth = request.DayOfMonth,
                Month = request.Month,
            };
        }

        public static RequestDTO FromQueuedRequest(ScheduledRequest.Queued request)
        {
            return new RequestDTO
            {
                Id = request.Id,
                Tag = request.Tag,
                ExecuteAt = request.ExecuteAt,
                ScheduledAt = DateTime.Today + request.ExecuteAt,
                IsCompleted = request.IsCompleted,
                CompletedAt = request.CompletedAt,
            };
        }
    }
}
