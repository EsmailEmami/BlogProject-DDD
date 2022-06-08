namespace Blog.Application.Interfaces;

public interface IUserRoleAppService : IDisposable
{
    Task<bool> AddUserRoleAsync(Guid userId, Guid roleId);
    Task<List<Guid>> GetAllUserRolesIdAsync(Guid userId);
}