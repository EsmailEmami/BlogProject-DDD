using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Infra.Data.Context;

namespace Blog.Infra.Data.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public bool IsEmailExists(string email) =>
        Db.Users.Any(x => x.Email.Equals(email));
}