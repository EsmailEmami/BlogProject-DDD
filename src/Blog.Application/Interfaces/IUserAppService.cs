using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;

namespace Blog.Application.Interfaces;

public interface IUserAppService : IDisposable
{
    List<User> GetAllUsers();
    User? GetUserByEmail(string email);
    void Update(UpdateUserViewModel user);
    void Remove(Guid userId);

    DashboardViewModel GetUserDashboard(Guid userId);
}