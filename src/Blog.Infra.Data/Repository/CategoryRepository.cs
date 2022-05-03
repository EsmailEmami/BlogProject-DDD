using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Infra.Data.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }
}