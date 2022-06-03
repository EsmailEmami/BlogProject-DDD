using System.Data;
using System.Data.SqlClient;

namespace Blog.Services.Api.SetupExtensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddScoped<IDbConnection>(_ =>
            new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}