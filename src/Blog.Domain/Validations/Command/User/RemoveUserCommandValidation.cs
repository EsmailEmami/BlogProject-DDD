using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.Command.User;

public class RemoveUserCommandValidation : UserValidation<RemoveUserCommand, bool>
{
    public RemoveUserCommandValidation()
    {
        ValidateId();
    }
}