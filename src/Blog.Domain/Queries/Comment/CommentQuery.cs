using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.Comment;

public abstract class CommentQuery<TResult> : Query<TResult>
{
    public Guid Id { get; set; }
    public Guid UserId { get; protected set; }
    public Guid BlogId { get; protected set; }
}