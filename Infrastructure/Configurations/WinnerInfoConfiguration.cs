using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class WinnerInfoConfiguration : IEntityTypeConfiguration<WinnerInfo>
    {
        public void Configure(EntityTypeBuilder<WinnerInfo> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(p => p.PlayerName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(n => n.NumberOfPlayers)
                .IsRequired();
            builder.Property(c => c.GameCategory)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.GameTime)
                .IsRequired();
            builder.Property(d => d.GameDate)
                .IsRequired();
        }
    }
}