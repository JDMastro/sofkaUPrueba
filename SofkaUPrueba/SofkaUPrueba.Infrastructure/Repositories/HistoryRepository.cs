using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure.Persistence;

namespace SofkaUPrueba.Infrastructure.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly AppDbContext _entities;

        public HistoryRepository(AppDbContext context) => _entities = context;

        public async Task AddHistory(History history)
        {
            await _entities.History.AddAsync(history);
        }

        public dynamic GetHistory()
        {
            var query = from h in _entities.History
                        join p in _entities.Players on h.PlayerId equals p.Id
                        select (new { p.Username, h.Score, h.Id });
            return query;
        }
    }
}
