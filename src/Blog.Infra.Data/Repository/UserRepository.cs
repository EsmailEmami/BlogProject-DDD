using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;
using Dapper;
using System.Data;

namespace Blog.Infra.Data.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }

    public bool IsEmailExists(string email)
    {
        string query = "SELECT (CASE WHEN EXISTS( " +
                       "SELECT NULL " +
                       "FROM [User].[Users] " +
                       "WHERE [Email] = @Email) " +
                       "THEN 1 ELSE 0 END) AS [Value]";

        return Db.QuerySingleOrDefault<bool>(query, new
        {
            email
        }, Transaction);
    }

    public User GetUserByEmail(string email)
    {
        string query = "SELECT [Id],[FirstName],[LastName],[Email],[IsDeleted],[Password] " +
                       "FROM [User].[Users]" +
                       "WHERE [Email] = @Email";

        return Db.QuerySingleOrDefault<User>(query, new
        {
            email
        }, Transaction);
    }

    public string GetUserPasswordByEmail(string email)
    {
        string query = "SELECT [Password] FROM [User].[Users]" +
                       "WHERE [Email] = @Email";

        return Db.QuerySingleOrDefault<string>(query, new
        {
            email
        }, Transaction);
    }

    public DashboardViewModel GetUserDashboard(Guid userId)
    {
        string query = "SELECT [FirstName],[LastName],[Email] " +
                       "FROM [User].[Users]" +
                       "WHERE [Id] = @Id";

        return Db.QuerySingleOrDefault<DashboardViewModel>(query, new
        {
            userId
        }, Transaction);
    }
}