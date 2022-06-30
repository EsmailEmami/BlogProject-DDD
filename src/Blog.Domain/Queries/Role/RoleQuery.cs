using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.Role;

public abstract class RoleQuery<TResult> : Query<TResult>
{
    public Guid RoleId { get; protected set; }
}