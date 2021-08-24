using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BingoContext : DbContext, IBingoContext
    {
        public DbSet<BingoSentence> BingoSentences { get; set; }
        public DbSet<WinnerInfo> WinnerInfos { get; set; }

        public BingoContext(DbContextOptions<BingoContext> options) : base(options) { }
    }
}