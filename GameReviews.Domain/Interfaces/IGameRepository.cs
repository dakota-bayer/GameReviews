using GameReviews.Entities;

namespace GameReviews.Domain.Interfaces;

public interface IGameRepository
{
    Task<Game> GetAsync(Guid id);

    Task<Game> CreateAsync(Game game);
}
