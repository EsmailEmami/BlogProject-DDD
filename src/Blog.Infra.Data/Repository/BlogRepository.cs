using Blog.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Blog.Infra.Data.Repository;

public class BlogRepository : Repository<Domain.Models.Blog>, IBlogRepository
{
    public BlogRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }
}