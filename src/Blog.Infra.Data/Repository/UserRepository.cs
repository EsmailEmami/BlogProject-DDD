using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;
using Dapper;
using System.Data;

namespace Blog.Infra.Data.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IDbConnection db) : base(db)
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
        });
    }

    public User GetUserByEmail(string email)
    {
        string query = "SELECT [Id],[FirstName],[LastName],[Email],[IsDeleted],[Password] " +
                       "FROM [User].[Users]" +
                       "WHERE [Email] = @Email";

        return Db.QuerySingleOrDefault<User>(query, new
        {
            email
        });
    }

    public string GetUserPasswordByEmail(string email)
    {
        string query = "SELECT [Password] FROM [User].[Users]" +
                       "WHERE [Email] = @Email";

        return Db.QuerySingleOrDefault<string>(query, new
        {
            email
        });
    }

    public DashboardViewModel GetUserDashboard(Guid userId)
    {
        string query = "SELECT [FirstName],[LastName],[Email] " +
                       "FROM [User].[Users]" +
                       "WHERE [Id] = @Id";

        return Db.QuerySingleOrDefault<DashboardViewModel>(query, new
        {
            Id = userId
        });
    }

    public List<UserForShowViewModel> GetUsers(int skip, int take, string? search)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@Skip", skip);
        parameters.Add("@Take", take);

        if (!string.IsNullOrEmpty(search)) parameters.Add("@Search", search);

        return Db.Query<UserForShowViewModel>("[User].[uspGetUsers]", parameters,
            commandType: CommandType.StoredProcedure).ToList();
    }

    public List<UserForShowViewModel> GetAdmins(int skip, int take, string? search)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@Skip", skip);
        parameters.Add("@Take", take);

        if (!string.IsNullOrEmpty(search)) parameters.Add("@Search", search);

        return Db.Query<UserForShowViewModel>("[User].[uspGetAdmins]", parameters,
            commandType: CommandType.StoredProcedure).ToList();
    }

    public int GetUsersCount(string? search)
    {
        string query = "SELECT COUNT(*) FROM [User].[Users]";

        if (!string.IsNullOrEmpty(search))
        {
            query += " WHERE ([FirstName] LIKE N'%@Search%') OR " +
                     "([LastName] LIKE N'%@Search%') OR " +
                     "([Email] LIKE N'%@Search%')";
        }

        return Db.QuerySingleOrDefault<int>(query, new { search });
    }

    public int GetAdminsCount(string? search)
    {
        string query = "SELECT COUNT(*) FROM [User].[Users]" +
                       "INNER JOIN [Permission].[UserRoles] " +
                       "ON [User].[Users].[Id] = [Permission].[UserRoles].[UserId]";

        if (!string.IsNullOrEmpty(search))
        {
            query += " WHERE ([FirstName] LIKE N'%@Search%') OR " +
                     "([LastName] LIKE N'%@Search%') OR " +
                     "([Email] LIKE N'%@Search%')";
        }

        return Db.QuerySingleOrDefault<int>(query, new { search });
    }
}