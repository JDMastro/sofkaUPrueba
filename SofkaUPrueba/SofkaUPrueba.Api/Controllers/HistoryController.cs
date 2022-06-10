using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SofkaUPrueba.Api.Response;
using SofkaUPrueba.Core.DTOs;
using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Interfaces;

namespace SofkaUPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HistoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService HistoryService, IMapper mapper)
        {
            _historyService = HistoryService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddHistory(HistoryDto historyDto)
        {
            var history = _mapper.Map<History>(historyDto);
            await _historyService.AddHistory(history);
            historyDto = _mapper.Map<HistoryDto>(history);
            var response = new ApiResponse<HistoryDto>(historyDto);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get ()
        {
            var response = new ApiResponse<dynamic>(_historyService.GetHistory());
            return Ok(response);
        }
    }
}
