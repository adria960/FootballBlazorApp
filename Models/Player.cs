namespace FootballBlazorApp.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        [Column("player_id")]
        public int PlayerId { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("position")]
        public string? Position { get; set; }

        [Column("team_id")]
        public int TeamId { get; set; }

        public Team Team { get; set; } = null!;
    }


}
