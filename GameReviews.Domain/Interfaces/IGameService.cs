using GameReviews.Contracts.Models;

namespace GameReviews.Domain.Interfaces;

public interface IGameService
{
    Task<Game> GetAsync(Guid id);

    Task<IEnumerable<Game>> GetAllAsync();

    Task<Game> CreateAsync(GameCreateRequest request);
}
