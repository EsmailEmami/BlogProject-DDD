using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Infra.Data.Repository;

public class BlogTagRepository : Repository<BlogTag>, IBlogTagRepository
{
    public BlogTagRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }
}