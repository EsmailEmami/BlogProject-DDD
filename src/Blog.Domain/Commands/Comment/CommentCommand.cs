using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.Comment;

public abstract class CommentCommand<TResult> : Command<TResult>
{
    public Guid Id { get; set; }
    public Guid UserId { get; protected set; }
    public Guid BlogId { get; protected set; }
    public string Title { get; protected set; }
    public string CommentMessage { get; protected set; }
}