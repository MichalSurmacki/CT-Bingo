using System;

namespace Domain.Models
{
    public class Player
    {
        public Guid Id { get; }
        public string ConnectionId { get; set; }
        public string Name { get; }
        public int Points { get; set; }

        public Player(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
    }
}