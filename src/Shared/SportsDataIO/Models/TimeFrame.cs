using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatStore.Shared.SportsDataIO.Models
{
    public class TimeFrame
    {
        public int Id { get; set; }
        public int? SeasonType { get; set; }
        public int? Season { get; set; }
        public int? Week { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? FirstGameStart { get; set; }
        public DateTime? FirstGameEnd { get; set; }
        public DateTime? LastGameEnd { get; set; }
        public bool? HasGames { get; set; }
        public bool? HasStarted { get; set; }
        public bool? HasEnded { get; set; }
        public bool? HasFirstGameStarted { get; set; }
        public bool? HasFirstGameEnded { get; set; }
        public bool? HasLastGameEnded { get; set; }
        public string? ApiSeason { get; set; }
        public string? ApiWeek { get; set; }
    }
}
