using Blog.Domain.Validations.User;

namespace Blog.Domain.Commands.User;

public class RegisterNewUserCommand : UserCommand
{
    public RegisterNewUserCommand(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}