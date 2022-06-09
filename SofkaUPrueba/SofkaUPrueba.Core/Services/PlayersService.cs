using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Interfaces;

namespace SofkaUPrueba.Core.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepository _playersRepository;
        public PlayersService(IPlayersRepository playersRepository) => _playersRepository = playersRepository;

        public async Task AddPlayer(Players player)
        {
            var checkPlayer = await _playersRepository.CheckUserNameOfPlayer(player.Username);
            if (checkPlayer == null)
                await _playersRepository.AddPlayer(player);
            else
                throw new Exception("Username is already registered");

        }
    }
}
