namespace FootballBlazorApp.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Match
    {
        [Column("match_id")]
        public int MatchId { get; set; }

        [Column("match_date")]
        public DateTime MatchDate { get; set; }

        [Column("home_score")]
        public int? HomeScore { get; set; }

        [Column("away_score")]
        public int? AwayScore { get; set; }

        [Column("home_team_id")]
        public int HomeTeamId { get; set; }

        [Column("away_team_id")]
        public int AwayTeamId { get; set; }

        public Team HomeTeam { get; set; } = null!;
        public Team AwayTeam { get; set; } = null!;
    }


}
