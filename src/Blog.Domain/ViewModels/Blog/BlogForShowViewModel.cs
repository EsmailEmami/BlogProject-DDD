namespace Blog.Domain.ViewModels.Blog;

public class BlogForShowViewModel
{
    public Guid BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string Summary { get; set; }
    public DateTime PostedAt { get; set; }
    public string ImageFile { get; set; }
    public int CommentsCount { get; set; }
    public List<string> Tags { get; set; } = new();
}