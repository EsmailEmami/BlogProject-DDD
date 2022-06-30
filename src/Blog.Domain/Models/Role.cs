using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[Permission].[Roles]")]
public class Role : Entity
{
    protected Role() { }

    public Role(Guid roleId, string roleName)
    {
        Id = roleId;
        RoleName = roleName.ToUpper().Replace(" ","");

        UserRoles = new List<UserRole>();
    }

    public string RoleName { get; private set; }

    [Write(false)]
    public ICollection<UserRole> UserRoles { get; protected set; }
}