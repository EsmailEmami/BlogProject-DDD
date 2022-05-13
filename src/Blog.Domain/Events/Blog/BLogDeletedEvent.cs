using Blog.Domain.Core.Events;

namespace Blog.Domain.Events.Blog;

public class BLogDeletedEvent : Event
{
    public BLogDeletedEvent(string imageName)
    {
        ImageName = imageName;
    }

    public string ImageName { get; private set; }
}