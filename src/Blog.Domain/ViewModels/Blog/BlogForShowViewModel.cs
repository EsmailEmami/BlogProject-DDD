namespace Blog.Domain.ViewModels.Blog;

public class BlogForShowViewModel
{
    public BlogForShowViewModel() { }
    public BlogForShowViewModel(Guid blogId, string blogTitle, string summary, DateTime postedAt, string imageFile, int commentsCount, List<string> tags)
    {
        BlogId = blogId;
        BlogTitle = blogTitle;
        Summary = summary;
        PostedAt = postedAt;
        ImageFile = imageFile;
        CommentsCount = commentsCount;
        Tags = tags;
    }

    public Guid BlogId { get; private set; }
    public string BlogTitle { get; private set; }
    public string Summary { get; private set; }
    public DateTime PostedAt { get; private set; }
    public string ImageFile { get; private set; }
    public int CommentsCount { get; private set; }
    public List<string> Tags { get; private set; }
}