using Blog.Application.ViewModels.User;
using Blog.Domain.Models;

namespace Blog.Application.Interfaces;

public interface IUserAppService : IDisposable
{
    IList<User> GetAllUsers();
    void Register(UserViewModel user);
    void Update(UserViewModel user);
    void Remove(Guid userId);
}