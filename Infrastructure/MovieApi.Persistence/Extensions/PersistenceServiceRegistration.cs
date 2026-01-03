using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApi.Persistence.Context;

namespace MovieApi.Persistence.Extensions;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MovieContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLServer")));

        return services;
    }
}
