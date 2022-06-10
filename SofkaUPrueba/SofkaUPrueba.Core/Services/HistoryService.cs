using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Interfaces;

namespace SofkaUPrueba.Core.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HistoryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task AddHistory(History history)
        {
            await _unitOfWork.HistoryRepository.AddHistory(history);
            await _unitOfWork.SaveChangesAsync();
        }

        public dynamic GetHistory()
        {
            return _unitOfWork.HistoryRepository.GetHistory();
        }
    }
}
