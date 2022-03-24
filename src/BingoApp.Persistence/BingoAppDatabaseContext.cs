using Microsoft.EntityFrameworkCore;

using BingoApp.Domain;
using BingoApp.Persistence.Configuration;
using BingoApp.Business.Infrastructure;

namespace BingoApp.Persistence;
public class BingoAppDatabaseContext : DbContext, IBingoAppDatabaseContext
{
    public BingoAppDatabaseContext(DbContextOptions<BingoAppDatabaseContext> options)
        : base(options)
    {
    }
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Numbers> Numbers { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new TicketConfiguration());
        builder.ApplyConfiguration(new NumbersConfiguration());
    }

}
