using StatStore.Shared.Local.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatStore.Loader.Core.Models
{
    public abstract class ScheduledRequest
    {
        public ScheduledRequest() { }

        public ScheduledRequest(RequestDTO dto)
        {
            Tag = dto.Tag;
            ExecuteAt = dto.ExecuteAt;
            Team = dto.Team;
            TargetId = dto.TargetId;
            Week = dto.Week;
            Season = dto.Season;
            Minutes = dto.Minutes;
            Date = dto.Date;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Tag { get; set; } = string.Empty;
        public TimeSpan ExecuteAt { get; set; }
        public string? Team { get; set; }
        public int? TargetId { get; set; }
        public int? Week { get; set; }
        public int? Season { get; set; }
        public int? Minutes { get; set; }
        public DateTime? Date { get; set; }

        public class Daily : ScheduledRequest
        {
            public Daily() { }
            public Daily(RequestDTO dto)
                : base(dto) { }
        }

        public class Oneoff : ScheduledRequest
        {
            public Oneoff() { }
            public Oneoff(RequestDTO dto)
                : base(dto)
            {

                DayOfMonth = dto.DayOfMonth;
                Month = dto.Month;
                DayOfWeek = dto.DayOfWeek;
            }
            public int? DayOfMonth { get; set; }
            public int? Month { get; set; }
            public DayOfWeek? DayOfWeek { get; set; }
        }

        public class OneoffSpan : Oneoff
        {
            public OneoffSpan() { }
            public OneoffSpan(RequestDTO dto) : base(dto)
            {
                Frequency = dto.Frequency ?? new();
                Durration = dto.Durration ?? new();
            }

            public TimeSpan Frequency { get; set; }
            public TimeSpan Durration { get; set; }
        }

        public class Weekly : ScheduledRequest
        {
            public Weekly() { }
            public Weekly(RequestDTO dto)
                : base(dto)
            {
                Day = dto.DayOfWeek;
            }

            public DayOfWeek? Day { get; set; }
        }

        public class WeeklySpan : Weekly
        {
            public WeeklySpan() { }
            public WeeklySpan(RequestDTO dto)
                : base(dto)
            {
                Frequency = dto.Frequency ?? new();
                Durration = dto.Durration ?? new();
            }

            public TimeSpan Frequency { get; set; }
            public TimeSpan Durration { get; set; }
        }

        public class Monthly : ScheduledRequest
        {
            public Monthly() { }
            public Monthly(RequestDTO dto)
                : base(dto)
            {
                DayOfMonth = dto.DayOfMonth;
            }

            public int? DayOfMonth { get; set; }
        }

        public class Annual : ScheduledRequest
        {
            public Annual() { }
            public Annual(RequestDTO dto)
                : base(dto)
            {
                DayOfMonth = dto.DayOfMonth;
                Month = dto.Month;
            }

            public int? DayOfMonth { get; set; }
            public int? Month { get; set; }
        }

        public class Queued : ScheduledRequest
        {
            public Queued() { }
            public Queued(ScheduledRequest request)
            {
                Id = request.Id;
                Tag = request.Tag;
                ExecuteAt = request.ExecuteAt;
                IsCompleted = false;
                ScheduledAt = DateTime.Today + request.ExecuteAt;
                CompletedAt = null;
            }

            public DateTime ScheduledAt { get; set; }
            public bool IsCompleted { get; set; }
            public DateTime? CompletedAt { get; set; }
        }
    }
}
