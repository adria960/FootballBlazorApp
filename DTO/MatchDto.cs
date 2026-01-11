namespace FootballBlazorApp.DTO
{

    public class MatchDto
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
    }
}

