using System;
using System.Collections.Generic;
using Application.Dtos;
using Application.Models;

namespace Application.Services.Interfaces
{
    public interface IGamesService
    {
        PlayerReadDto AddPlayerToLobby(string playerName);
        void RemovePlayerFromLobby(Guid playerId);
        void MovePlayerFromLobbyToGame(Guid playerId, Guid gameId);
        List<PlayerReadDto> GetPlayerListByGameId(Guid gameId);

        GameReadDto AddGame(string sentencesCategory, int numberOfSentences, string gameName);
        void RemoveGame(Guid gameId);
        List<GameReadDto> GetAllGames();
        GameReadDto GetGameById(Guid gameId);
    }
}