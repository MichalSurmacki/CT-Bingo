using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IBingoContext
    {
        public DbSet<BingoSentence> BingoSentences { get; set; }
        public DbSet<WinnerInfo> WinnerInfos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}