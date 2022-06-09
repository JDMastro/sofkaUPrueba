using SofkaUPrueba.Core.Entities;

namespace SofkaUPrueba.Core.Interfaces
{
    public interface IPlayersRepository
    {
        Task<Players> Login(Players players);
        Task AddPlayer(Players player);
        Task<Players> CheckUserNameOfPlayer(string username);
    }
}
