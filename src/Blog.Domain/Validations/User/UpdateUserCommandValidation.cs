using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.User;

public class UpdateUserCommandValidation : UserValidation<UpdateUserCommand>
{
    public UpdateUserCommandValidation()
    {
        ValidateId();
        ValidateFirstName();
        ValidateLastName();
        ValidateEmail();
    }
}