using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofkaUPrueba.Core.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionsService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Questions> GetQuestionByIdCategory(int Categoryid)
        {
            return await _unitOfWork.QuestionsRepository.GetQuestionByIdCategory(Categoryid);
        }
    }
}
