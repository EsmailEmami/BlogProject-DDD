using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.Category;

public abstract class CategoryQuery<TResult> : Query<TResult>
{
    public Guid Id { get; protected set; }
}