using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class GameReadDto
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public DateTime StartTime { get; }
        public List<PlayerReadDto> Players { get; private set; }
        public List<BingoSentenceDto> BingoSentences { get; private set; }
    }
}