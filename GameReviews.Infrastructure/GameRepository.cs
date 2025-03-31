using GameReviews.Domain.Interfaces;
using GameReviews.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameReviews.Infrastructure
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _dbContext;

        public GameRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Game> CreateAsync(Game game)
        {
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
            return game;
        }

        public Task<Game> GetAsync(Guid id)
        {
            return _dbContext.Games.FirstOrDefaultAsync(g => g.GameId == id);
        }
    }
}
