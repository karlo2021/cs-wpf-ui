// IBingoAppDatabaseContext.cs
//
// © 2022.

using BingoApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BingoApp.Business.Infrastructure;
public interface IBingoAppDatabaseContext
{
    public DbSet<Ticket> Tickets { get; }
    public DbSet<Numbers> Numbers { get; }
    public int SaveChanges();
}
