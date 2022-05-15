using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.User;

public abstract class UserQuery<TResult> : Query<TResult>
{
    public Guid UserId { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }
}