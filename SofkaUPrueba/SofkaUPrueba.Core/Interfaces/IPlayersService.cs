﻿using SofkaUPrueba.Core.Entities;

namespace SofkaUPrueba.Core.Interfaces
{
    public interface IPlayersService
    {
        Task AddPlayer(Players player);
    }
}
