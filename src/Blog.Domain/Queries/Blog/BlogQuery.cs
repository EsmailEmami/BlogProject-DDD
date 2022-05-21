using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.Blog;

public abstract class BlogQuery<TResult> : Query<TResult>
{
    public Guid Id { get; protected set; }
    public Guid AuthorId { get; protected set; }
}