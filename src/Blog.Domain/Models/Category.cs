using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[Category].[Categories]")]
public class Category : Entity
{
    protected Category() { }
    public Category(Guid id, string categoryTitle)
    {
        Id = id;
        CategoryTitle = categoryTitle;
    }

    public string CategoryTitle { get; private set; }

    #region Relations

    public ICollection<BlogCategory> Blogs { get; protected set; }

    #endregion
}