namespace Blog.Application.Interfaces;

public interface IBlogCategoryAppService : IDisposable
{
    void AddBlogCategory(Guid blogId, Guid categoryId);
    void DeleteBlogCategory(Guid blogCategoryId);
    Task<List<Guid>> GetBlogCategories(Guid blogId);
}