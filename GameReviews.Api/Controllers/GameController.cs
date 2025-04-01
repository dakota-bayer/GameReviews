using GameReviews.Contracts.Models;
using GameReviews.Domain;
using GameReviews.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameReviews.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _service;

    public GameController(IGameService service) : base()
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Game), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] GameCreateRequest request)
    {
        var game = await _service.CreateAsync(request);

        return CreatedAtAction(nameof(GetAsync), new { id = game.GameId }, game);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync(string id)
    {
        var game = await _service.GetAsync(Guid.Parse(id));

        if (game == null)
        {
            return NotFound("Game not found!");
        }

        return Ok(game);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Game>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var games = await _service.GetAllAsync();

        return Ok(games);
    }
}
