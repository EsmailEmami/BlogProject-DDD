using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.Blog;

public abstract class BlogCommand<TResult> : Command<TResult>
{
    public Guid Id { get; protected set; }
    public Guid AuthorId { get; protected set; }
    public string BlogTitle { get; protected set; }
    public string Summary { get; protected set; }
    public string Description { get; protected set; }
    public string ImageFile { get; protected set; }
    public string ReadTime { get; protected set; }
}