// TicketConfiguration.cs
//
// © 2022.

using System;
using BingoApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BingoApp.Persistence.Configuration;
internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(p => p.Date).HasColumnType("datetime2");
        builder.Property(p => p.Title).HasMaxLength(10);
        builder.HasIndex(p => p.Id).IsUnique();
        builder.HasIndex(p => p.Title).IsUnique();
    }
}
