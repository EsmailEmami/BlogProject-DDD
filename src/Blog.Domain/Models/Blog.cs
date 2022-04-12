using Blog.Domain.Core.Models;

namespace Blog.Domain.Models;

public class Blog : EntityAudit
{
    public Blog(Guid id, string blogTitle)
    {
        Id = id;
        BlogTitle = blogTitle;
    }

    protected Blog() { }

    public string BlogTitle { get; private set; }
}