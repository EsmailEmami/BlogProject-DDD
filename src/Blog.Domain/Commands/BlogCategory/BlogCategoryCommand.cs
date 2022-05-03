using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.BlogCategory;

public abstract class BlogCategoryCommand<TResult> : Command<TResult>
{
    public Guid Id { get; protected set; }
    public Guid BlogId { get; protected set; }
    public Guid CategoryId { get; protected set; }
}