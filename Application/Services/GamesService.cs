using System;
using System.Collections.Generic;
using System.Linq;
using Application.Dtos;
using Application.Interfaces;
using Application.Models;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Models;

namespace Application.Services
{
    public class GamesService : IGamesService
    {
        private readonly GamesStorage _gamesStorage;
        private readonly IBingoContext _context;
        private readonly IMapper _mapper;

        public GamesService(GamesStorage gamesStorage, IBingoContext context, IMapper mapper)
        {
            _gamesStorage = gamesStorage;
            _context = context;
            _mapper = mapper;
        }
        
        public GameReadDto AddGame(string sentencesCategory, int numberOfSentences, string gameName)
        {
            var sentences = _context.BingoSentences.Where(b => b.Category.Equals(sentencesCategory)).ToList();
            sentences = sentences.OrderBy(x => Guid.NewGuid()).Take(numberOfSentences).ToList();
            var game = new Game(sentences, gameName);
            _gamesStorage.AddGame(game);
            return _mapper.Map<GameReadDto>(game);
        }

        public PlayerReadDto AddPlayerToLobby(string playerName)
        {
            Player player;
            string name = playerName;
            if(_gamesStorage.LobbyPlayers.Any(p => p.Name.Equals(playerName)))
            {
                int num = _gamesStorage.LobbyPlayers.Where(p => (p.Name + "_").Equals(playerName + "_")).Count();
                name = playerName + "_" + num;
            }
            player = new Player(name);
            _gamesStorage.AddPlayerToLobby(player);
            return _mapper.Map<PlayerReadDto>(player);
        }

        public List<GameReadDto> GetAllGames() => _mapper.Map<List<GameReadDto>>(_gamesStorage.Games);

        public GameReadDto GetGameById(Guid gameId) => _mapper.Map<GameReadDto>(_gamesStorage.Games.Where(g => g.Id.Equals(gameId)));

        public List<PlayerReadDto> GetPlayerListByGameId(Guid gameId) 
            => _mapper.Map<List<PlayerReadDto>>(_gamesStorage.Games.Where(g => g.Id.Equals(gameId)).FirstOrDefault().Players);

        public void MovePlayerFromLobbyToGame(Guid playerId, Guid gameId) => _gamesStorage.MovePlayerFromLobbyToGame(playerId, gameId);

        public void RemoveGame(Guid gameId) => _gamesStorage.RemoveGame(gameId);

        public void RemovePlayerFromLobby(Guid playerId) => _gamesStorage.RemovePlayerFromLobby(playerId);
    }
}