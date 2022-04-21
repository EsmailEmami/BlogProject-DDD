using Blog.Domain.Models;
using Dapper.FluentMap.Mapping;

namespace Blog.Infra.Data.Mappings;

public class UserMap:EntityMap<User>
{
    public UserMap()
    {
        Map(x => x.Id).ToColumn("UserId");
    }
}