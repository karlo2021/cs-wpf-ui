// BingoAppDatabaseContextFactory.cs
//
// © 2022.

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BingoApp.Persistence.Infrastructure;

public class BingoAppDatabaseContextFactory : IDesignTimeDbContextFactory<BingoAppDatabaseContext>
{
    public const string ConnectionString = "Server=localhost,8000;Database=BingoAppDb;User Id=SA;Password=Labovi123;";
    public BingoAppDatabaseContext CreateDbContext(string[] args)
    {
        var contextOptions = new DbContextOptionsBuilder<BingoAppDatabaseContext>();

        _ = contextOptions.UseSqlServer(ConnectionString);
        _ = contextOptions.EnableDetailedErrors();

        return new BingoAppDatabaseContext(contextOptions.Options);
    }
}
