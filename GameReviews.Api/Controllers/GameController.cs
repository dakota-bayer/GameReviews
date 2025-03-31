using GameReviews.Domain;
using GameReviews.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameReviews.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameRepository _repo;

    public GameController(IGameRepository repo) : base()
    {
        _repo = repo;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Models.Game), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] Models.Game game)
    {
        var newGame = await _repo.CreateAsync(new GameReviews.Entities.Game
        {
            GameId = Guid.NewGuid(),
            Name = game.Name,
            Description = game.Description,
            ReleaseDate = game.ReleaseDate
        });

        return CreatedAtAction(nameof(GetAsync), new { id = newGame.GameId }, new Models.Game
        {
            GameId = newGame.GameId.ToString(),
            Name = newGame.Name,
            Description = newGame.Description,
            ReleaseDate = newGame.ReleaseDate
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Models.Game), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync(string id)
    {
        var game = await _repo.GetAsync(Guid.Parse(id));

        if (game == null)
        {
            return NotFound("Game not found!");
        }

        return Ok(new Models.Game
        {
            GameId = game.GameId.ToString(),
            Name = game.Name,
            Description = game.Description,
            ReleaseDate = game.ReleaseDate
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Models.Game>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new List<Models.Game>
        {
            new Models.Game
            {
                GameId = Guid.NewGuid().ToString(),
                Name = "Game Name",
                Description = "Game Description",
                ReleaseDate = DateTime.Now
            }
        });
    }
}
