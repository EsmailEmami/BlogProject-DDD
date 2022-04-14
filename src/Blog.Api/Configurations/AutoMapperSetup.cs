using Blog.Application.AutoMapper;

namespace Blog.Services.Api.Configurations;

public static class AutoMapperSetup
{
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
    }
}