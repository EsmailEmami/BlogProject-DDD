using Blog.Domain.Models;

namespace Blog.Domain.Interfaces;

public interface IBlogTagRepository : IRepository<BlogTag>
{
    List<Guid> GetBlogTagsIdByBlog(Guid blogId);
}