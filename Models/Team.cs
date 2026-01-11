using System.Numerics;

namespace FootballBlazorApp.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        [Column("team_id")]
        public int TeamId { get; set; }

        [Column("team_name")]
        public string TeamName { get; set; } = string.Empty;

        [Column("country")]
        public string? Country { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }


}
