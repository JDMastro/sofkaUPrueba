using SofkaUPrueba.Core.Entities;

namespace SofkaUPrueba.Core.Interfaces
{
    public interface IPlayersRepository
    {
        Task<Players> Login(Players players);
    }
}
