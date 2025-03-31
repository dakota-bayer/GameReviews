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

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _dbContext.Games.ToListAsync();
        }

        public async Task<Game> GetAsync(Guid id)
        {
            return await _dbContext.Games.FirstOrDefaultAsync(g => g.GameId == id);
        }
    }
}
