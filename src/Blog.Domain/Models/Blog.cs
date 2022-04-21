using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[Blog].[Blogs]")]
public class Blog : Entity
{
    protected Blog() { }
    public Blog(Guid id, string blogTitle)
    {
        Id = id;
        BlogTitle = blogTitle;
    }

    public string BlogTitle { get; private set; }
}