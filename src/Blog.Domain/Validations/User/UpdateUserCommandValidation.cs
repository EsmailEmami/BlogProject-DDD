using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.User;

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