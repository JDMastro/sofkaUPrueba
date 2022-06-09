using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure.Persistence;

namespace SofkaUPrueba.Infrastructure.Repositories
{
    public class OptionsRepository : IOptionsRepository
    {
        private readonly AppDbContext _entities;

        public OptionsRepository(AppDbContext context) => _entities = context;
    }
}
