using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[Tag].[BlogTags]")]
public class BlogTag: Entity
{
    protected BlogTag() { }

    public BlogTag(Guid id, Guid blogId, Guid tagId)
    {
        Id = id;
        BlogId = blogId;
        TagId = tagId;
    }

    public Guid BlogId { get; private set; }
    public Guid TagId { get; private set; }

    #region Relations

    [Write(false)]
    public Blog Blog { get; protected set; }
    [Write(false)]
    public Tag Tag { get; protected set; }

    #endregion
}