using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BingoSentenceConfiguration : IEntityTypeConfiguration<BingoSentence>
    {
        public void Configure(EntityTypeBuilder<BingoSentence> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(s => s.Sentence)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(c => c.Category)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}