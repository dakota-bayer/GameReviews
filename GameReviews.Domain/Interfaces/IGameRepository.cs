using GameReviews.Entities;

namespace GameReviews.Domain.Interfaces;

public interface IGameRepository
{
    Task<Game> GetAsync(Guid id);

    Task<IEnumerable<Game>> GetAllAsync();

    Task<Game> CreateAsync(Game game);
}
