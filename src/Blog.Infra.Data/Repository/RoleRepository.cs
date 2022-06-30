using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Role;
using Dapper;

namespace Blog.Infra.Data.Repository;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(IDbConnection db) : base(db)
    {
    }

    public UpdateRoleViewModel? GetRoleForUpdate(Guid roleId)
    {
        string query = "SELECT [Id] AS [RoleId], [RoleName] " +
                       "FROM [Permission].[Roles] " +
                       "WHERE [Id] = @RoleId";

        return Db.QuerySingleOrDefault<UpdateRoleViewModel>(query, new { roleId });
    }
}