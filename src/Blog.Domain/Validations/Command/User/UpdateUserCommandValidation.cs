using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.Command.User;

public class UpdateUserCommandValidation : UserCommandValidation<UpdateUserCommand, bool>
{
    public UpdateUserCommandValidation()
    {
        ValidateId();
        ValidateFirstName();
        ValidateLastName();
        ValidateEmail();
    }
}