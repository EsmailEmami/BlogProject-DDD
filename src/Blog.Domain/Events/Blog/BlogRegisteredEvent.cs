using Blog.Domain.Core.Events;
using Blog.Domain.Models;

namespace Blog.Domain.Events.Blog;

public class BlogRegisteredEvent : Event
{
    public BlogRegisteredEvent(Guid blogId, string imageBase64String, string imageName)
    {
        BlogId = blogId;
        ImageBase64String = imageBase64String;
        ImageName = imageName;
    }

    public Guid BlogId { get; private set; }
    public string ImageBase64String { get; private set; }
    public string ImageName { get; private set; }
}