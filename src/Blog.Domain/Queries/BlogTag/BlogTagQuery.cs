using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.BlogTag;

public abstract class BlogTagQuery<TResult> : Query<TResult>
{
    public Guid BlogId { get; protected set; }
    public Guid TagId { get; protected set; }
}