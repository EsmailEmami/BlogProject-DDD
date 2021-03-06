using Blog.Domain.Validations.Command.User;

namespace Blog.Domain.Commands.User;

public class UpdateUserCommand : UserCommand<bool>
{
    public UpdateUserCommand(Guid id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateUserCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}