using FootballBlazorApp.Data;
using FootballBlazorApp.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballBlazorApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TeamsController(AppDbContext db) => _db = db;

        // GET: api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            var teams = await _db.Teams
                .Select(t => new TeamDto
                {
                    TeamId = t.TeamId,
                    TeamName = t.TeamName,
                    Country = t.Country
                })
                .ToListAsync(); // ✅ EF prepoznaje async
            return Ok(teams);
        }

        // GET: api/teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetTeam(int id)
        {
            var team = await _db.Teams
                .Where(t => t.TeamId == id)
                .Select(t => new TeamDto
                {
                    TeamId = t.TeamId,
                    TeamName = t.TeamName,
                    Country = t.Country
                })
                .FirstOrDefaultAsync(); // ✅ async za single element

            if (team == null) return NotFound();
            return Ok(team);
        }
    }


}
