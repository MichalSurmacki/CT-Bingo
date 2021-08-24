using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Application.Models
{
    public class GamesStorage
    {
        public List<Game> Games { get; private set; } = new List<Game>();
        public List<Player> LobbyPlayers { get; private set; } = new List<Player>();

        public void AddGame(Game newGame) => Games.Add(newGame);
        public void AddPlayerToLobby(Player player) => LobbyPlayers.Add(player);
        public Game GetGameById(Guid gameId)
        {
            var game = Games.Where(g => g.Id.Equals(gameId)).FirstOrDefault();
            return game;
        }
        public Player GetLobbyPlayerById(Guid playerId)
        {
            var player = LobbyPlayers.Where(p => p.Id.Equals(playerId)).FirstOrDefault();
            return player;
        }

        public List<Player> GetPlayerListByGameId(Guid gameId)
        {
            var game = GetGameById(gameId);
            return game.Players;
        }

        public void MovePlayerFromLobbyToGame(Guid playerId, Guid gameId)
        {
            var player = LobbyPlayers.Where(p => p.Id.Equals(playerId)).FirstOrDefault();
            var game = Games.Where(g => g.Id.Equals(gameId)).FirstOrDefault();
            if(player != null && game != null)
            {
                LobbyPlayers.Remove(player);
                game.AddPlayer(player);
            }
        }

        public void RemoveGame(Guid gameId)
        {
            var game = GetGameById(gameId);
            Games.Remove(game);           
        }

        public void RemovePlayerFromLobby(Guid playerId)
        {
            var player = LobbyPlayers.Where(p => p.Id.Equals(playerId)).Single();
            LobbyPlayers.Remove(player);
        }
    }
}