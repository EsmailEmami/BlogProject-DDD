using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[Permission].[UserRoles]")]
public class UserRole : Entity
{
    protected UserRole() { }
    public UserRole(Guid id, Guid userId, Guid roleId)
    {
        Id = id;
        UserId = userId;
        RoleId = roleId;
    }

    public Guid UserId { get; private set; }
    public Guid RoleId { get; private set; }

    #region Relations

    [Write(false)]
    public User User { get; protected set; }
    [Write(false)]
    public Role Role { get; protected set; }

    #endregion
}