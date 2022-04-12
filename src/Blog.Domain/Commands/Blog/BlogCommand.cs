using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.Blog;

public abstract class BlogCommand : Command
{
    public Guid Id { get; protected set; }
    public string BlogTitle { get; protected set; }
}