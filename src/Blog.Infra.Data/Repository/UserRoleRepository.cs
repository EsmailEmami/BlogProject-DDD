using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Dapper;
using System.Data;

namespace Blog.Infra.Data.Repository;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(IDbConnection db) : base(db)
    {
    }

    public List<Guid> GetAllUserRolesId(Guid userId)
    {
        string query = "SELECT [RoleId] " +
                       "FROM [Permission].[UserRoles] " +
                       "WHERE [UserId] = @UserId";

        return Db.Query<Guid>(query, new
        {
            userId
        }).ToList();
    }
}