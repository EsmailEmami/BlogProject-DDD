using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;

namespace Blog.Application.Interfaces;

public interface IUserAppService : IDisposable
{
    Task<User?> GetUserByEmailAsync(string email);
    void Update(UpdateUserViewModel user);
    void Remove(Guid userId);
    Task<DashboardViewModel?> GetUserDashboardAsync(Guid userId);
    void UpdateUserPassword(UpdateUserPasswordViewModel user);
}