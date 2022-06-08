using Blog.Domain.Models;

namespace Blog.Application.Interfaces;

public interface IRoleAppService :IDisposable
{
    Task<Guid> AddRoleAsync(string roleName);
    Task<List<Role>> GetAllRolesAsync();
}