using Blog.Domain.Core.Query;

namespace Blog.Domain.Queries.Tag;

public abstract class TagQuery<TResult> : Query<TResult>
{
    public Guid Id { get; protected set; }
    public string TagName { get; protected set; }
}