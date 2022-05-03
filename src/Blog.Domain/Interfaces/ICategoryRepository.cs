using Blog.Domain.Models;

namespace Blog.Domain.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    bool IsCategoryExist(Guid categoryId);
}