using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[User].[Users]")]
public class User : Entity
{
    protected User() { }

    public User(Guid id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    #region Relations

    [Write(false)]
    public ICollection<Blog> Blogs { get; protected set; }
    [Write(false)]
    public ICollection<Comment> Comments { get; protected set; }
    [Write(false)]
    public ICollection<UserRole> UserRoles { get; protected set; }

    #endregion

    public void SetPassword(string password) => Password = password;
    
    [Write(false)]
    public string FullName => FirstName + " " + LastName;
}