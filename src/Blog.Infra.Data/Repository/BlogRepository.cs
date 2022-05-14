using Blog.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using Blog.Domain.ViewModels.Blog;
using Dapper;

namespace Blog.Infra.Data.Repository;

public class BlogRepository : Repository<Domain.Models.Blog>, IBlogRepository
{
    public BlogRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }

    public bool IsBlogExist(Guid blogId)
    {
        string query = "SELECT (CASE WHEN EXISTS( " +
                       "SELECT NULL " +
                       "FROM [Blog].[Blogs] " +
                       "WHERE [Id] = @BlogId) " +
                       "THEN 1 ELSE 0 END) AS [Value]";

        return Db.QuerySingleOrDefault<bool>(query, new
        {
            blogId
        }, Transaction);
    }

    public UpdateBlogViewModel GetBlogForUpdate(Guid blogId)
    {
        return null;
    }
}