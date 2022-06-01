using Blog.Domain.Models;
using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    bool IsCategoryExist(Guid categoryId);
    UpdateCategoryViewModel? GetCategoryForUpdate(Guid categoryId);
    List<CategoryForShowViewModel> GetAllCategories();
}