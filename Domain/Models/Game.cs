using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Game
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public DateTime StartTime { get; }
        public List<Player> Players { get; private set; }
        public List<BingoSentence> BingoSentences { get; private set; }
        
        public Game(List<BingoSentence> bingoSentences, string gameName)
        {
            Players = new List<Player>();
            BingoSentences = bingoSentences;
            StartTime = DateTime.Now;
            Id = Guid.NewGuid();
            Name = gameName;
        }

        public void AddPlayer(Player player)
        {
            if(player == null)
                throw new ArgumentNullException("Argument 'player' connot be null");
            Players.Add(player);
        }

        public void CreateRandomSentences(List<BingoSentence> sentences, int numberOfSentences)
        {
            if(sentences.Count < numberOfSentences)
                throw new ArgumentException($"Cannot draw {numberOfSentences} sentences from list 'sentences' of length {sentences.Count}");
            if(sentences.Count != numberOfSentences)
                BingoSentences = sentences.OrderBy(x => Guid.NewGuid()).Take(numberOfSentences).ToList();
            else
                BingoSentences = sentences;
        }
    }
}