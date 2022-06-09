using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure.Persistence;

namespace SofkaUPrueba.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _entities;
        private readonly IPlayersRepository _playersRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IOptionsRepository _optionsRepository;
        private readonly IQuestionsRepository _questionsRepository;
        public UnitOfWork(AppDbContext context)
        {
            _entities = context;

        }

        public IPlayersRepository PlayersRepository => _playersRepository ?? new PlayersRepository(_entities);

        public ICategoriesRepository CategoryRepository => _categoriesRepository ?? new CategoriesRepository(_entities);

        public IOptionsRepository OptionsRepository => _optionsRepository ?? new OptionsRepository(_entities);

        public IQuestionsRepository QuestionsRepository => _questionsRepository ?? new QuestionsRepository(_entities);

        public void Dispose()
        {
            if(_entities != null)
                _entities.Dispose();
        }

        public void SaveChanges()
        {
            _entities.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _entities.SaveChangesAsync();
        }
    }
}
