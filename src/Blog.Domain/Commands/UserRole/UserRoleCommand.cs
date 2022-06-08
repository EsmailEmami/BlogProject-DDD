using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.UserRole;

public abstract class UserRoleCommand : Command<bool>
{
    public Guid Id { get; protected set; }
    public Guid UserId { get; protected set; }
    public Guid RoleId { get; protected set; }
}