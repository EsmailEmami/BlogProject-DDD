namespace Blog.Domain.ViewModels.Comment;

public class CommentForShowViewModel
{
    public Guid CommentId { get; set; }
    public string Title { get; set; }
    public string CommentMessage { get; set; }
    public DateTime CommentDate { get; set; }
}