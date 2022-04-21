using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("Blog.Blogs")]
public class Blog : Entity
{
    public Blog(Guid id, string blogTitle)
    {
        Id = id;
        BlogTitle = blogTitle;
    }

    protected Blog() { }

    public string BlogTitle { get; private set; }
}