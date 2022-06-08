using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.UserRole;

public abstract class UserRoleQuery<TResult> : Query<TResult>
{
    public Guid UserId { get; protected set; }
}