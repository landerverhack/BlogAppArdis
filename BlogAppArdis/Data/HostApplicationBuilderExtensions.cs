using Microsoft.EntityFrameworkCore;

namespace BlogAppArdis.Data;

public static class HostApplicationBuilderExtensions
{
    /// <summary>
    /// Registers <typeparamref name="TContext"/> using the SQLite EF Core provider.
    /// The connection string is read from configuration under
    /// ConnectionStrings:{TContext name}, falling back to a local "{TContext name}.db" file.
    /// </summary>
    public static void AddDbContextForSqlite<TContext>(this IHostApplicationBuilder builder)
        where TContext : DbContext
    {
        var contextName = typeof(TContext).Name;
        var connectionString = builder.Configuration.GetConnectionString(contextName)
            ?? $"Data Source={contextName}.db";

        builder.Services.AddDbContext<TContext>(options => options.UseSqlite(connectionString));
    }
}
