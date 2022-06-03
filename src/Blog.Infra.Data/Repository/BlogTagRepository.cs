using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Infra.Data.Repository;

public class BlogTagRepository : Repository<BlogTag>, IBlogTagRepository
{
    public BlogTagRepository(IDbConnection db) : base(db)
    {
    }

    public List<Guid> GetBlogTagsIdByBlog(Guid blogId)
    {
        throw new NotImplementedException();
    }
}