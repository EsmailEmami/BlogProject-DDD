using Blog.Domain.ViewModels.Blog;

namespace Blog.Application.Interfaces;

public interface IBlogAppService : IDisposable
{
    List<Domain.Models.Blog> GetAllBlogs();
    Task<Guid> Register(BlogViewModel blog);
    void Update(BlogViewModel blog);
    void Remove(Guid blogId);
}