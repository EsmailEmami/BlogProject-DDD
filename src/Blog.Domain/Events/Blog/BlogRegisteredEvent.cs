using Blog.Domain.Core.Events;

namespace Blog.Domain.Events.Blog;

public class BlogRegisteredEvent : Event
{
    public BlogRegisteredEvent(string imageBase64String, string imageName)
    {
        ImageBase64String = imageBase64String;
        ImageName = imageName;
    }

    public string ImageBase64String { get; private set; }
    public string ImageName { get; private set; }
}