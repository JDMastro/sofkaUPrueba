using Microsoft.EntityFrameworkCore;
using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure.Persistence;

namespace SofkaUPrueba.Infrastructure.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly AppDbContext _entities;

        public PlayersRepository(AppDbContext context) => _entities = context;

        public async Task AddPlayer(Players player)
        {
            await _entities.Players.AddAsync(player);
        }

        public async Task<Players> CheckUserNameOfPlayer(string username)
        {
            return await _entities.Players.FirstOrDefaultAsync(x => x.Username == username );
        }

        public async Task<Players> Login(Players players)
        {
            return await _entities.Players.FirstOrDefaultAsync(x => 
                  x.Username == players.Username 
                  && x.Password == players.Password );
        }
    }
}
