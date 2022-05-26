using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.BlogCategory;

public abstract class BlogCategoryQuery<TResult> : Query<TResult>
{
    public Guid BlogId { get; protected set; }
    public Guid CategoryId { get; protected set; }
}