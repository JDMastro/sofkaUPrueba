using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Exceptions;
using SofkaUPrueba.Core.Interfaces;

namespace SofkaUPrueba.Core.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayersService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task AddPlayer(Players player)
        {
            var checkPlayer = await _unitOfWork.PlayersRepository.CheckUserNameOfPlayer(player.Username);
            if (checkPlayer == null) { 
                await _unitOfWork.PlayersRepository.AddPlayer(player);
                await _unitOfWork.SaveChangesAsync();
            }
            else { 
                throw new BussineException("Username is already registered");
            }

        }
    }
}
