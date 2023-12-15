using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using API.Entity.Database;
using API.Database;

namespace API.BusinessLayer.Services;

internal static class DatabaseService
{
    internal static PooledDbContextFactory<DataContext> Factory = null!;

    internal static void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        using var context = new DataContext(GetOptions());
        var dbSet = context.Set<TEntity>();
        dbSet.Add(entity);
        context.SaveChanges();
    }

    internal static TEntity? GetEntity<TEntity>(object key) where TEntity : BaseEntity
    {
        using var context = new DataContext(GetOptions());
        var dbSet = context.Set<TEntity>();
        var entity = dbSet.Find(key);
        return entity;
    }

    internal static async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        using var context = new DataContext(GetOptions());
        var dbSet = context.Set<TEntity>();
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    internal static async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        using var context = new DataContext(GetOptions());
        var dbSet = context.Set<TEntity>();
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }

    private static DbContextOptions<DataContext> GetOptions()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        return optionsBuilder.UseNpgsql(DefaultConnection.ConnectionString).Options;
    }
}
