using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;
using Dapper;
using System.Data;

namespace Blog.Infra.Data.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    

    public bool IsEmailExists(string email)
    {
        string query = "SELECT (CASE WHEN EXISTS( " +
                       "SELECT NULL " +
                       "FROM [User].[Users] " +
                       "WHERE [Email] = @email) " +
                       "THEN 1 ELSE 0 END) AS[Value]";

        return Db.QuerySingleOrDefault<bool>(query, new
        {
            email
        });
    }

    public User GetUserByEmail(string email)
    {
        string query = "SELECT (CASE WHEN EXISTS( " +
                       "SELECT NULL " +
                       "FROM [User].[Users] " +
                       "WHERE [Email] = @email) " +
                       "THEN 1 ELSE 0 END) AS[Value]";

        return Db.QuerySingleOrDefault<User>(query, new
        {
            email
        });
    }

    public string GetUserPasswordByEmail(string email)
    {
        string query = "SELECT (CASE WHEN EXISTS( " +
                       "SELECT NULL " +
                       "FROM [User].[Users] " +
                       "WHERE [Email] = @email) " +
                       "THEN 1 ELSE 0 END) AS[Value]";

        return Db.QuerySingleOrDefault<string>(query, new
        {
            email
        });
    }

    public DashboardViewModel GetUserDashboard(Guid userId)
    {
        string query = "SELECT (CASE WHEN EXISTS( " +
                       "SELECT NULL " +
                       "FROM [User].[Users] " +
                       "WHERE [Email] = @email) " +
                       "THEN 1 ELSE 0 END) AS[Value]";

        return Db.QuerySingleOrDefault<DashboardViewModel>(query, new
        {
            userId
        });
    }

    public UserRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }
}