using SofkaUPrueba.Core.Entities;

namespace SofkaUPrueba.Core.Interfaces
{
    public interface IHistoryRepository
    {
        Task AddHistory(History history);
        dynamic GetHistory();
    }
}
