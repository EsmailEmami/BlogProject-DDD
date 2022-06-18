namespace Blog.Domain.ViewModels.Comment;

public class AddCommentViewModel
{
    public Guid UserId { get; set; }
    public Guid BlogId { get; set; }
    public string Title { get; set; }
    public string CommentMessage { get; set; }
}