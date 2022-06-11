using Microsoft.AspNetCore.Mvc;
using SofkaUPrueba.Core.Interfaces;

namespace SofkaUPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class QuestionsController : Controller
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService QuestionsService) => _questionsService = QuestionsService;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(new { data = await _questionsService.GetQuestionByIdCategory(id) });
        }


    }
}
