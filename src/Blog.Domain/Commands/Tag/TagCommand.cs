using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.Tag;

public abstract class TagCommand<TResult> : Command<TResult>
{
    public Guid Id { get; protected set; }
    public string TagName { get; protected set; }
}