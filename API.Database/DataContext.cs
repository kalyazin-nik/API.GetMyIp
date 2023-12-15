using Microsoft.EntityFrameworkCore;
using API.Entity.Database;

namespace API.Database;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    private const string SCHEMA = "api";
    private readonly Dictionary<string, string> _propertyNames = new()
    {
        { "Guid", "guid" },
        { "CreatedAt", "created_at" },
        { "UserId", "user_id" },
        { "Ip", "ip" },
        { "City", "city" },
        { "Region", "region" },
        { "Country", "country" },
        { "Location", "loc" },
        { "Organization", "org" },
        { "ZipCode", "zip" },
        { "TimeZone", "timezone" },
        { "Readme", "readme" }
    };

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<IpInfo> IpInfos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(c => c.Guid);
        modelBuilder.Entity<User>().Property(u => u.Guid).ValueGeneratedNever();
        modelBuilder.Entity<IpInfo>().HasKey(c => c.UserId);
        modelBuilder.Entity<IpInfo>().Property(u => u.UserId).ValueGeneratedNever();
        modelBuilder.Entity<User>().HasOne(u => u.IpInfo).WithOne(i => i.User).HasForeignKey<IpInfo>(i => i.UserId);
        modelBuilder.Entity<User>().Property(p => p.CreatedAt).HasColumnType("timestamp");
        AssignNameToTablesAndColumns<User>(modelBuilder, "users");
        AssignNameToTablesAndColumns<IpInfo>(modelBuilder, "ip_infos");
    }

    private void AssignNameToTablesAndColumns<TEntity>(ModelBuilder modelBuilder, string tableName) 
        where TEntity : BaseEntity
    {
        modelBuilder.Entity<TEntity>().ToTable(tableName, schema: SCHEMA);
        var properties = typeof(TEntity).GetProperties();

        foreach (var property in properties)
            if (_propertyNames.TryGetValue(property.Name, out string? columnName))
                modelBuilder.Entity<TEntity>().Property(property.Name).HasColumnName(columnName);
    }
}
