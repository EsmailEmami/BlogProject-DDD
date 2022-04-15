using Blog.Application.ViewModels.User;
using Blog.Domain.Models;

namespace Blog.Application.Interfaces;

public interface IUserAppService : IDisposable
{
    IList<User> GetAllUsers();
    User? GetUserByEmail(string email);
    void Update(UpdateUserViewModel user);
    void Remove(Guid userId);
}