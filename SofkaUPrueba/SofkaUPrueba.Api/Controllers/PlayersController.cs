using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SofkaUPrueba.Api.Response;
using SofkaUPrueba.Core.DTOs;
using SofkaUPrueba.Core.Interfaces;

namespace SofkaUPrueba.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayersService _playersService;

        public PlayersController(IPlayersService PlayersService, IMapper mapper)
        {
            _playersService = PlayersService;
            _mapper = mapper;
        }

        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Id", StringComparison.InvariantCultureIgnoreCase));
            var player = await _playersService.CheckMe(Int32.Parse(id.Value));
            var playerDto = _mapper.Map<PlayersDto>(player);
            var response = new ApiResponse<PlayersDto>(playerDto);

            if (response != null)
                return Ok(response);
            else
                return Unauthorized("No tienes autorizacion");
        }
    }
}
