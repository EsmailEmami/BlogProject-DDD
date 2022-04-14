using Blog.Domain.Core.Events;

namespace Blog.Domain.Events.User;

public class UserRegisteredEvent : Event
{
    public UserRegisteredEvent(Guid id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public Guid Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
}