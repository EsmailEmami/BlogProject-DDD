using Blog.Domain.Models;

namespace Blog.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    bool IsEmailExists(string email);
    bool IsUserExists(string email, string password);
    User? GetUserByEmail(string email);
}