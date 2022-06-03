using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Infra.Data.Repository;

public class BlogCategoryRepository : Repository<BlogCategory>, IBlogCategoryRepository
{
    public BlogCategoryRepository(IDbConnection db) : base(db)
    {
    }

    public List<Guid> GetBlogCategoriesIdByBlog(Guid blogId)
    {
        throw new NotImplementedException();
    }
}