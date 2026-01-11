using FootballBlazorApp.Data;
using FootballBlazorApp.DTO;
using FootballBlazorApp.Models;
using FootballBlazorApp.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly AppDbContext _db;

    public PlayersController(AppDbContext db)
    {
        _db = db;
    }

    // GET: api/players
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers()
    {
        var players = await _db.Players
            .Include(p => p.Team)
            .Select(p => new PlayerDto
            {
                PlayerId = p.PlayerId,
                Name = p.Name,
                TeamName = p.Team.TeamName,
                BirthDate = p.BirthDate,
                Position = p.Position
            })
            .ToListAsync();

        return Ok(players);
    }

    // GET: api/players/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerDto>> GetPlayer(int id)
    {
        var player = await _db.Players
            .Include(p => p.Team)
            .Where(p => p.PlayerId == id)
            .Select(p => new PlayerDto
            {
                PlayerId = p.PlayerId,
                Name = p.Name,
                TeamName = p.Team.TeamName,
                BirthDate = p.BirthDate,
                Position = p.Position
            })
            .FirstOrDefaultAsync();

        if (player == null)
            return NotFound();

        return Ok(player);
    }

}