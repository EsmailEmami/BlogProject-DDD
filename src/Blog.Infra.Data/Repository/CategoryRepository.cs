using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Category;
using Dapper;

namespace Blog.Infra.Data.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(IDbConnection db) : base(db)
    {
    }

    public bool IsCategoryExist(Guid categoryId)
    {
        string query = "SELECT (CASE WHEN EXISTS( " +
                       "SELECT NULL " +
                       "FROM [Category].[Categories] " +
                       "WHERE [Id] = @CategoryId) " +
                       "THEN 1 ELSE 0 END) AS [Value]";

        return Db.QuerySingleOrDefault<bool>(query, new
        {
            categoryId
        });
    }

    public UpdateCategoryViewModel? GetCategoryForUpdate(Guid categoryId)
    {
        string query = "SELECT [Id] AS [CategoryId],[CategoryTitle] " +
                       "FROM [Category].[Categories] WHERE [Id] = @CategoryId;";

        return Db.QuerySingleOrDefault<UpdateCategoryViewModel>(query, new { categoryId });
    }

    public List<CategoryForShowViewModel> GetAllCategories()
    {
        string query = "SELECT [Id] AS [CategoryId], [CategoryTitle] " +
            "FROM [Category].[Categories]";

        return Db.Query<CategoryForShowViewModel>(query).ToList();
    }

    public List<CategoryForShowViewModel> GetBlogCategories(Guid blogId)
    {
        string query = "SELECT [Categories].[Id] AS [CategoryId], [Categories].[CategoryTitle] " +
                       "FROM [Category].[BlogCategories] " +
                       "INNER JOIN [Category].[Categories] " +
                       "ON [Category].[BlogCategories].[CategoryId] = [Category].[Categories].[Id] " +
                       "WHERE [BlogCategories].[BlogId] = @BlogId";

        return Db.Query<CategoryForShowViewModel>(query, new { blogId }).ToList();
    }
}