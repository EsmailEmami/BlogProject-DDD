using Blog.Domain.Core.Commands;

namespace Blog.Domain.Commands.User;

public abstract class UserCommand<TResult> : Command<TResult>
{
    public Guid Id { get; protected set; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public string ConfirmPassword { get; protected set; }
}