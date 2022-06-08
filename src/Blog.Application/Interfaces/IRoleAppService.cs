namespace Blog.Application.Interfaces;

public interface IRoleAppService :IDisposable
{
    Task<Guid> AddRoleAsync(string roleName);
}