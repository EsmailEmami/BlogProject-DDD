﻿using Blog.Domain.ViewModels.Category;

namespace Blog.Application.Interfaces;

public interface ICategoryAppService : IDisposable
{
    Task<List<CategoryForShowViewModel>> GetAllCategoriesAsync();
    Task<Guid> AddCategoryAsync(AddCategoryViewModel category);
    void UpdateCategory(UpdateCategoryViewModel category);
    Task<UpdateCategoryViewModel?> GetCategoryForUpdate(Guid categoryId);
}