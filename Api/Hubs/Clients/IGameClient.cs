using System;
using System.Threading.Tasks;
using Application.Dtos;

namespace Api.Hubs.Clients
{
    public interface IGameClient
    {
        Task GameCreated(GameReadDto game);
        Task PlayerAddedToGame(PlayerReadDto player);
    }
}