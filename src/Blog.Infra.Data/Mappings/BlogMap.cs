using Dapper.FluentMap.Mapping;

namespace Blog.Infra.Data.Mappings;

public class BlogMap : EntityMap<Domain.Models.Blog>
{
    public BlogMap()
    {
        Map(x => x.Id).ToColumn("BlogId");
    }
}