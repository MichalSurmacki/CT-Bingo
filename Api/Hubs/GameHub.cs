using System;
using System.Threading.Tasks;
using Api.Hubs.Clients;
using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class GameHub : Hub<IGameClient>
    {
        private readonly IGamesService _gamesService;

        public GameHub(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }
        public async Task CreateGame(string sentencesCategory, int numberOfSentences, string gameName)
        {
            var game = _gamesService.AddGame(sentencesCategory, numberOfSentences, gameName);
            await Clients.All.GameCreated(game);
        }

        public async Task AddNewPlayer(string playerName)
        {
            var player = _gamesService.AddPlayerToLobby(playerName);
            await Clients.All.PlayerAddedToGame(player);

        }

        public async Task AddPlayerToGame(Guid playerId, Guid gameId)
        {
            _gamesService.MovePlayerFromLobbyToGame(playerId, gameId);
            await Groups.AddToGroupAsync(Context.ConnectionId, "game_" + gameId.ToString());
        }

    }
}