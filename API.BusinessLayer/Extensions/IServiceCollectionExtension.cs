using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using API.BusinessLayer.Services;
using API.Database;

namespace API.BusinessLayer.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>(options => options.UseNpgsql(DefaultConnection.ConnectionString));
        return services;
    }

    public static IServiceCollection AddDefaultConnections
        (this IServiceCollection services, string connectionString, string url)
    {
        DefaultConnection.ConnectionString = connectionString;
        DefaultConnection.Url = url;
        return services;
    }
}
