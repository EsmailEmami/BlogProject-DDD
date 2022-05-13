using Blog.Domain.Core.Events;

namespace Blog.Domain.Events.Blog;

public class BlogUpdatedEvent : Event
{
    public BlogUpdatedEvent(string imageBase64String, string imageName, string lastImageName)
    {
        ImageBase64String = imageBase64String;
        ImageName = imageName;
        LastImageName = lastImageName;
    }

    public string ImageBase64String { get; private set; }
    public string ImageName { get; private set; }
    public string LastImageName { get; private set; }
}