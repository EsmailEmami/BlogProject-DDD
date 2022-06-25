using Blog.Domain.Commands.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Validations.Command.User;

public class RegisterNewUserCommandValidation : UserCommandValidation<RegisterNewUserCommand, UserForShowViewModel>
{
    public RegisterNewUserCommandValidation()
    {
        ValidateFirstName();
        ValidateLastName();
        ValidateEmail();
        ValidatePassword();
    }
}