using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SofkaUPrueba.Core.Interfaces;

namespace SofkaUPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayersRepository _playersRepository;

        public AuthController(IPlayersRepository PlayersRepository, IMapper mapper)
        {
            _playersRepository = PlayersRepository;
            _mapper = mapper;
        }

    }
}
