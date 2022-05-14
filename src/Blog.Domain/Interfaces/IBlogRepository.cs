using Blog.Domain.ViewModels.Blog;

namespace Blog.Domain.Interfaces;

public interface IBlogRepository : IRepository<Models.Blog>
{
    bool IsBlogExist(Guid blogId);
    UpdateBlogViewModel GetBlogForUpdate(Guid blogId);
}