using Blog.Infra.Data.Mappings;
using Dapper.FluentMap;

namespace Blog.Services.Api.Configurations;

public static class DapperMappingSetup
{
    public static void RegisterDapperMappings()
    {
        FluentMapper.Initialize(config =>
        {
            config.AddMap(new BlogMap());
            config.AddMap(new UserMap());
        });
    }
}