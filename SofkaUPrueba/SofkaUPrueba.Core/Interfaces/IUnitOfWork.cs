namespace SofkaUPrueba.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayersRepository PlayersRepository { get; }
        ICategoriesRepository CategoryRepository { get; }
        IOptionsRepository OptionsRepository { get; }
        IQuestionsRepository QuestionsRepository { get; }

        IHistoryRepository HistoryRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
