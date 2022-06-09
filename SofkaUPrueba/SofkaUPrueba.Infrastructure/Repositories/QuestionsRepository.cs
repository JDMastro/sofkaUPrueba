using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure.Persistence;

namespace SofkaUPrueba.Infrastructure.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly AppDbContext _entities;

        public QuestionsRepository(AppDbContext context) => _entities = context;
    }
}
