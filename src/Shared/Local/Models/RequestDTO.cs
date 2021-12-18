using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatStore.Shared.Local.Models
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string Tag { get; set; } = string.Empty;
        public TimeSpan ExecuteAt { get; set; }
        public string? Team { get; set; }
        public int? TargetId { get; set; }
        public int? Week { get; set; }
        public int? Season { get; set; }
        public int? Minutes { get; set; }
        public DateTime? Date { get; set; }
        public string RequestType { get; set; } = string.Empty;
        public int? Month { get; set; }
        public int? DayOfMonth { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public TimeSpan? Frequency { get; set; }
        public TimeSpan? Durration { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
