using Blog.Domain.Core.Events;

namespace Blog.Domain.Events.Blog;

public class BlogRegisteredEvent : Event
{
    public BlogRegisteredEvent(Guid id, string blogTitle)
    {
        Id = id;
        BlogTitle = blogTitle;
    }

    public Guid Id { get; set; }
    public string BlogTitle { get; private set; }
}