using Blog.Domain.ViewModels.Category;

namespace Blog.Application.Interfaces;

public interface ICategoryAppService : IDisposable
{
    Task<Guid> AddCategoryAsync(AddCategoryViewModel category);
}