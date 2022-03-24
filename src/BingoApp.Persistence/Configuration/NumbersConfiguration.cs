// TicketConfiguration.cs
//
// © 2022.

using BingoApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BingoApp.Persistence.Configuration;

internal class NumbersConfiguration : IEntityTypeConfiguration<Numbers>
{
    public void Configure(EntityTypeBuilder<Numbers> builder)
    {
        builder.Property(p => p.Value).HasMaxLength(2);
        builder.HasIndex(p => p.Id).IsUnique();
    }
}
