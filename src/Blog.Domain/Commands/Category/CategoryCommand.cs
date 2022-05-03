using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.Category;

public abstract class CategoryCommand<TResult> : Command<TResult>
{
    public Guid Id { get; protected set; }
    public string CategoryTitle { get; protected set; }
}