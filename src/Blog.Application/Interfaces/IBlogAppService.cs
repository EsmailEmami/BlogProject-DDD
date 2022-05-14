using Blog.Domain.ViewModels.Blog;

namespace Blog.Application.Interfaces;

public interface IBlogAppService : IDisposable
{
    List<Domain.Models.Blog> GetAllBlogs();
    Task<Guid> Register(AddBlogViewModel blog);
    void Update(UpdateBlogViewModel blog);
    void Remove(Guid blogId);
    UpdateBlogViewModel TestQuery();
}