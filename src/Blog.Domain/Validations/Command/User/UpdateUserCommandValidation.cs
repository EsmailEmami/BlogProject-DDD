using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.Command.User;

public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand, bool>
{
    public UpdateUserCommandValidation()
    {
        ValidateId();
        ValidateFirstName();
        ValidateLastName();
        ValidateEmail();
    }
}