using System;

namespace Application.Dtos
{
    public class PlayerReadDto
    {
        public Guid Id { get; }
        public string ConnectionId { get; set; }
        public string Name { get; }
        public int Points { get; set; }
    }
}