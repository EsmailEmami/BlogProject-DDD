using Blog.Domain.Core.Models;

namespace Blog.Domain.Models;

public class User : EntityAudit
{
    public User(Guid id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
}