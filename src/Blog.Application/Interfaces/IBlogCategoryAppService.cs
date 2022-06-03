namespace Blog.Application.Interfaces;

public interface IBlogCategoryAppService : IDisposable
{
    Task<bool> AddBlogCategoryAsync(Guid blogId, Guid categoryId);
    void DeleteBlogCategory(Guid blogCategoryId);
    Task<List<Guid>> GetBlogCategories(Guid blogId);
}