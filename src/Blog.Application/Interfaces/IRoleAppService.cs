using Blog.Domain.Models;
using Blog.Domain.ViewModels.Role;

namespace Blog.Application.Interfaces;

public interface IRoleAppService :IDisposable
{
    Task<Guid> AddRoleAsync(string roleName);
    Task<List<Role>> GetAllRolesAsync();
    Task<UpdateRoleViewModel> GetRoleForUpdateAsync(Guid roleId);
    Task<Role> UpdateRoleAsync(UpdateRoleViewModel role);
    Task<List<Guid>> GetRolesIdAsync(List<string> rolesName);
}