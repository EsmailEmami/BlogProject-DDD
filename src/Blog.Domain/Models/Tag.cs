using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[Tag].[Tags]")]
public class Tag : Entity
{
    protected Tag() { }

    public Tag(Guid tagId, string tagName)
    {
        TagName = tagName;
        Id = tagId;
        Blogs = new List<BlogTag>();
    }

    public string TagName { get; private set; }

    #region Relations

    [Write(false)]
    public ICollection<BlogTag> Blogs { get; protected set; }

    #endregion
}