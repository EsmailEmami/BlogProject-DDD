using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Blog.Services.Api.SetupExtensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddScoped<IDbConnection>(_ =>
            new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(s =>
        {
            IDbConnection conn = s.GetRequiredService<IDbConnection>();
            conn.Open();
            return conn.BeginTransaction();
        });


        return services;
    }
}