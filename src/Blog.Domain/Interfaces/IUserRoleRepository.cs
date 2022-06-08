using Blog.Domain.Models;

namespace Blog.Domain.Interfaces;

public interface IUserRoleRepository : IRepository<UserRole>
{
    List<Guid>? GetAllUserRolesId(Guid userId);
}