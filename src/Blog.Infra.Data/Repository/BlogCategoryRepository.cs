using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Infra.Data.Repository;

public class BlogCategoryRepository : Repository<BlogCategory>, IBlogCategoryRepository
{
    public BlogCategoryRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }

    public List<Guid> GetBlogCategoriesIdByBlog(Guid blogId)
    {
        throw new NotImplementedException();
    }
}