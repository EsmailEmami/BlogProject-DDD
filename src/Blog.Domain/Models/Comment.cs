using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[User].[Comments]")]
public class Comment : Entity
{
    protected Comment() { }
    public Comment(Guid commentId, Guid userId, Guid blogId, string title, string commentMessage)
    {
        Id = commentId;
        UserId = userId;
        BlogId = blogId;
        Title = title;
        CommentMessage = commentMessage;
        CommentDate = DateTime.Now;
    }


    public Guid UserId { get; private set; }
    public Guid BlogId { get; private set; }
    public string Title { get; private set; }
    public string CommentMessage { get; private set; }
    public DateTime CommentDate { get; private set; }

    #region Relations

    [Write(false)]
    public Blog Blog { get; protected set; }
    [Write(false)]
    public User User { get; protected set; }

    #endregion
}