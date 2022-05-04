using Blog.Domain.ViewModels.BlogCategory;

namespace Blog.Application.Interfaces;

public interface IBlogCategoryAppService : IDisposable
{
    void AddBlogCategory(AddBlogCategoryViewModel blogCategory);
}