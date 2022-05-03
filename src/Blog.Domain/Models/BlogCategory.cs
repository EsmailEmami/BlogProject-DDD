using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[Category].[BlogCategories]")]
public class BlogCategory : Entity
{
    protected BlogCategory() { }

    public BlogCategory(Guid id, Guid blogId, Guid categoryId)
    {
        Id = id;
        BlogId = blogId;
        CategoryId = categoryId;
    }

    public Guid BlogId { get; private set; }
    public Guid CategoryId { get; private set; }

    #region Relations

    public Blog Blog { get; protected set; }
    public Category Category { get; protected set; }

    #endregion
}