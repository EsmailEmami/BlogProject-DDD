using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.Blog;

public abstract class BlogCommand<TResult> : Command<TResult>
{
    public Guid Id { get; protected set; }
    public string BlogTitle { get; protected set; }
}