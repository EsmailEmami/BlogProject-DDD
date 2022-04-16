using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    bool IsEmailExists(string email);
    bool IsUserExists(string email, string password);
    User? GetUserByEmail(string email);

    DashboardViewModel? GetUserDashboard(Guid userId);
}