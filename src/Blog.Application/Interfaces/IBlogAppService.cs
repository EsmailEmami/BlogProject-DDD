using Blog.Domain.ViewModels.Blog;

namespace Blog.Application.Interfaces;

public interface IBlogAppService : IDisposable
{
    Task<Guid> Register(AddBlogViewModel blog);
    void UpdateBlog(UpdateBlogViewModel blog);
    void DeleteBlog(Guid blogId);
    Task<UpdateBlogViewModel?> GetBlogForUpdate(Guid blogId);
    Task<List<BlogForShowViewModel>> GetAuthorBlogs(Guid authorId);
}