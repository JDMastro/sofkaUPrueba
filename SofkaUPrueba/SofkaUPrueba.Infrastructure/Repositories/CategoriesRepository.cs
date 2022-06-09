using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure.Persistence;

namespace SofkaUPrueba.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _entities;

        public CategoriesRepository(AppDbContext context) => _entities = context;
    }
}
