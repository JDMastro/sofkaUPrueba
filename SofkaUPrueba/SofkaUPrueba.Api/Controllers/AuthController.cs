using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SofkaUPrueba.Api.Response;
using SofkaUPrueba.Core.DTOs;
using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SofkaUPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayersService _playersService;
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;

        public AuthController(IPasswordService passwordService, IPlayersService PlayersService, IMapper mapper, IConfiguration configuration)
        {
            _playersService = PlayersService;
            _mapper = mapper;
            _configuration = configuration;
            _passwordService = passwordService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddPlayer(PlayersDto playersDto)
        {
            var player = _mapper.Map<Players>(playersDto);
            player.Password = _passwordService.Hash(player.Password);
            await _playersService.AddPlayer(player);
            playersDto = _mapper.Map<PlayersDto>(player);
            var response = new ApiResponse<PlayersDto>(playersDto);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var validations = await IsValidPlayer(loginDto);
            if (validations.Item1)
            {
                var token = GenerateToken(validations.Item2);
                return Ok(new { access_token = token });
            }
            return NotFound("Credenciales invalidas");
        }

        private async Task<(bool, Players)> IsValidPlayer(LoginDto loginDto)
        {
            var player = _mapper.Map<Players>(loginDto);
            var playerResult = await _playersService.Login(player);
            var isValid = _passwordService.Check(playerResult.Password, loginDto.Password);


            return (isValid, playerResult);
        }

        private string GenerateToken(Players players)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var claims = new[]
            {
               new Claim(ClaimTypes.Email, players.Username),
               new Claim("Id", players.Id.ToString()),
            };

            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
