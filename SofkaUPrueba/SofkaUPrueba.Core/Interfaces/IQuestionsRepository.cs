using SofkaUPrueba.Core.Entities;

namespace SofkaUPrueba.Core.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<Questions> GetQuestionByIdCategory(int Categoryid);
    }
}
