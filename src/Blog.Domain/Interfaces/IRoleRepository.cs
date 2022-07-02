using Blog.Domain.Models;
using Blog.Domain.ViewModels.Role;

namespace Blog.Domain.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    UpdateRoleViewModel? GetRoleForUpdate(Guid roleId);
    List<Guid> GetRolesIdByNames(List<string> rolesName);
}