namespace SofkaUPrueba.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayersRepository PlayersRepository { get; }
        ICategoriesRepository CategoryRepository { get; }
        IOptionsRepository OptionsRepository { get; }
        IQuestionsRepository QuestionsRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
