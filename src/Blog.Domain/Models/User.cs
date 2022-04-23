using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[User].[Users]")]
public class User : Entity
{
    public static readonly User None = new(Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
    
    protected User() { }

    public User(Guid id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Blogs = new List<Blog>();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    #region Relations

    public ICollection<Blog> Blogs { get; private set; }

    #endregion

    public void SetPassword(string password) => Password = password;
}