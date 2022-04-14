using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.User;

public class RemoveUserCommandValidation : UserValidation<RemoveUserCommand>
{
    public RemoveUserCommandValidation()
    {
        ValidateId();
    }
}