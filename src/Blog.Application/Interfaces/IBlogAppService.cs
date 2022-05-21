using Blog.Domain.ViewModels.Blog;

namespace Blog.Application.Interfaces;

public interface IBlogAppService : IDisposable
{
    Task<Guid> Register(AddBlogViewModel blog);
    void Update(UpdateBlogViewModel blog);
    void Remove(Guid blogId);
    Task<UpdateBlogViewModel?> GetBlogForUpdate(Guid blogId);
}