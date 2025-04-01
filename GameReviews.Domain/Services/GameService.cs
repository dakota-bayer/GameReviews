using GameReviews.Contracts.Models;
using GameReviews.Domain.Interfaces;

namespace GameReviews.Domain.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _repo;

    public GameService(IGameRepository repo)
    {
        _repo = repo;
    }

    public async Task<Game> CreateAsync(GameCreateRequest request)
    {
        var newGame = await _repo.CreateAsync(new Entities.Game
        {
            GameId = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            ReleaseDate = request.ReleaseDate
        });

        return new Game
        {
            GameId = newGame.GameId.ToString(),
            Name = newGame.Name,
            Description = newGame.Description,
            ReleaseDate = newGame.ReleaseDate
        };
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return (await _repo.GetAllAsync()).Select(x => new Game
        {
            GameId = x.GameId.ToString(),
            Name = x.Name,
            Description = x.Description,
            ReleaseDate = x.ReleaseDate
        });
    }

    public async Task<Contracts.Models.Game> GetAsync(Guid id)
    {
        var game = await _repo.GetAsync(id);

        return new Contracts.Models.Game
        {
            GameId = game.GameId.ToString(),
            Name = game.Name,
            Description = game.Description,
            ReleaseDate = game.ReleaseDate
        };
    }
}
