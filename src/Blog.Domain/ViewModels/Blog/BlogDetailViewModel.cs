namespace Blog.Domain.ViewModels.Blog;

public class BlogDetailViewModel
{
    public Guid BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public DateTime PostedAt { get; set; }
    public string ImageFile { get; set; }
    public int CommentsCount { get; set; }
}