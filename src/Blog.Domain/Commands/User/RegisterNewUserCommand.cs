using Blog.Domain.Validations.Command.User;

namespace Blog.Domain.Commands.User;

public class RegisterNewUserCommand : UserCommand<Guid>
{
    public RegisterNewUserCommand(string firstName, string lastName, string email, string password, string confirmPassword)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}