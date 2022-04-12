using Blog.Domain.Core.Events;

namespace Blog.Domain.Events.Blog;

public class BlogUpdatedEvent:Event
{
    public BlogUpdatedEvent(Guid id, string blogTitle)
    {
        Id = id;
        BlogTitle = blogTitle;
    }

    public Guid Id { get; set; }
    public string BlogTitle { get; private set; }
}