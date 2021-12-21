namespace StatStore.Loader.SportsDataIO
{
    internal static class Constants
    {
        internal const string sportsDataIOBaseUrl = "https://api.sportsdata.io/v3/nfl";
        internal const string bye = "BYE";
        internal const string allowKnownOrigins = "AllowKnownOrigins";

        internal record RouteTag
        {
            internal const string scores = "scores/json";
            internal const string stats = "stats/json";
            internal const string projections = "projections/json";
        }

        internal record RequestTag
        {
            internal const string scoresByWeek = "ScoresByWeek";
            internal const string schedules = "Schedules";
            internal const string standings = "Standings";
            internal const string stadiums = "Stadiums";
            internal const string timeframe = "Timeframes";
            internal const string boxScores = "BoxScoreV3";
            internal const string boxDelta = "BoxScoresDeltaV3";
            internal const string news = "News";
            internal const string fantasyOwnership = "PlayerOwnership";
            internal const string teams = "Teams";
            internal const string injuries = "Injuries";
            internal const string players = "Players";
            internal const string playerSeason = "PlayerSeasonStats";
            internal const string playerGameWeek = "PlayerGameStatsByWeek";
            internal const string playerGameWeekDelta = "PlayerGameStatsByWeekDelta";
            internal const string playerProjection = "PlayerGameProjectionStatsByWeek";
            internal const string defenseSeason = "FantasyDefenseBySeason";
            internal const string defenseGame = "FantasyDefenseByGame";
            internal const string projectedDefense = "FantasyDefenseProjectionsByGame";
            internal const string teamSeason = "TeamSeasonStats";
            internal const string teamGame = "TeamGameStats";
        }
    }
}
