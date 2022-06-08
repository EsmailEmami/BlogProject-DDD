using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.Role;

public abstract class RoleCommand<TResult> : Command<TResult>
{
    public Guid RoleId { get; protected set; }
    public string RoleName { get; protected set; }
}