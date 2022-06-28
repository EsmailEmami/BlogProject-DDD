using Blog.Application.ViewModels.User;
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
    Task<FilterUsersViewModel> GetUsers(int pageId, int take, string? search);
    Task<FilterUsersViewModel> GetAdmins(int pageId, int take, string? search);
    Task<UpdateUserViewModel> GetUserForUpdateAsync(Guid userId);
}