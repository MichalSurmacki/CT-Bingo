using System;

namespace Domain.Models
{
    public class WinnerInfo
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string GameCategory { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime GameDate { get; set; }
        public TimeSpan GameTime { get; set; }
    }
}