using Blog.Domain.Core.Events;

namespace Blog.Domain.Events.Blog;

public class BlogUpdatedEvent : Event
{
    public BlogUpdatedEvent(Guid blogId, string imageBase64String, string imageName, string lastImageName)
    {
        BlogId = blogId;
        ImageBase64String = imageBase64String;
        ImageName = imageName;
        LastImageName = lastImageName;
    }

    public Guid BlogId { get; }
    public string ImageBase64String { get; }
    public string ImageName { get; }
    public string LastImageName { get; }
}