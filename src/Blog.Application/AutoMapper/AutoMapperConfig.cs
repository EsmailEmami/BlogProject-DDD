namespace Blog.Application.AutoMapper;

public class AutoMapperConfig
{
    public static Type[] RegisterMappings()
    {
        return new[]
        {
            typeof(DomainToViewModelMappingProfile),
            typeof(ViewModelToDomainMappingProfile)
        };
    }
}