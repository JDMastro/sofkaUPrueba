using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SofkaUPrueba.Api.Response;
using SofkaUPrueba.Core.DTOs;
using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Interfaces;

namespace SofkaUPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayersService _playersService;

        public AuthController(IPlayersService PlayersService, IMapper mapper)
        {
            _playersService = PlayersService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(PlayersDto playersDto)
        {
            var player = _mapper.Map<Players>(playersDto);
            await _playersService.AddPlayer(player);
            playersDto = _mapper.Map<PlayersDto>(player);
            var response = new ApiResponse<PlayersDto>(playersDto);
            return Ok(response);
        }

    }
}
