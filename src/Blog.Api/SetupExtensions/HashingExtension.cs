using Blog.Domain.Services.Hash;

namespace Blog.Services.Api.SetupExtensions;

public static class HashingExtension
{
    public static IServiceCollection AddCustomizedHash(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<HashingOptions>(configuration.GetSection(HashingOptions.Hashing));
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        return services;
    }
}