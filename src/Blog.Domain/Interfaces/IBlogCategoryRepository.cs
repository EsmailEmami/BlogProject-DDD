using Blog.Domain.Models;

namespace Blog.Domain.Interfaces;

public interface IBlogCategoryRepository : IRepository<BlogCategory>
{
    List<Guid>? GetBlogCategoriesIdByBlog(Guid blogId);
}