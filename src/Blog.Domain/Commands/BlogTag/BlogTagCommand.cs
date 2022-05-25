using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.BlogTag;

public abstract class BlogTagCommand : Command<bool>
{
    public Guid Id { get; protected set; }
    public Guid BlogId { get; protected set; }
    public Guid TagId { get; protected set; }
}