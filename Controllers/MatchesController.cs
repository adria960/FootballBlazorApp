using FootballBlazorApp.Data;
using FootballBlazorApp.DTO;
using FootballBlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MatchesController : ControllerBase
{
    private readonly AppDbContext _db;

    public MatchesController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches()
    {
        var matches = await _db.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Select(m => new MatchDto
            {
                MatchId = m.MatchId,
                MatchDate = m.MatchDate,
                HomeTeam = m.HomeTeam.TeamName,
                AwayTeam = m.AwayTeam.TeamName,
                HomeScore = m.HomeScore,
                AwayScore = m.AwayScore
            })
            .ToListAsync();

        return Ok(matches);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MatchDto>> GetMatch(int id)
    {
        var match = await _db.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Where(m => m.MatchId == id)
            .Select(m => new MatchDto
            {
                MatchId = m.MatchId,
                MatchDate = m.MatchDate,
                HomeTeam = m.HomeTeam.TeamName,
                AwayTeam = m.AwayTeam.TeamName,
                HomeScore = m.HomeScore,
                AwayScore = m.AwayScore
            })
            .FirstOrDefaultAsync();

        if (match == null) return NotFound();
        return Ok(match);
    }
}

