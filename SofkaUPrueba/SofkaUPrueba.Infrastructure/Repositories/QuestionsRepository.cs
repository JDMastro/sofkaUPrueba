using Microsoft.EntityFrameworkCore;
using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Enumerations;
using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure.Persistence;

namespace SofkaUPrueba.Infrastructure.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly AppDbContext _entities;

        public QuestionsRepository(AppDbContext context) => _entities = context;

        public async Task<Questions> GetQuestionByIdCategory(int Categoryid)
        {
            var random = new Random();
            var cantidadDePreguntasPorRonda = (int)QuestionEnum.CantidadDePreguntasPorRonda;
            var randomQuestionId = random.Next(Categoryid * cantidadDePreguntasPorRonda - 4, Categoryid * cantidadDePreguntasPorRonda+1);
            var result = await _entities.Questions
                .Include(x => x.Options)
                .Where(x => x.Id == randomQuestionId )
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
