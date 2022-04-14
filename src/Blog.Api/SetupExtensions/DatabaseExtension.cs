using Blog.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services.Api.SetupExtensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment env)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            if (!env.IsProduction())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }
        });

        services.AddDbContext<EventStoreSqlContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            if (!env.IsProduction())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }
        });

        return services;
    }
}