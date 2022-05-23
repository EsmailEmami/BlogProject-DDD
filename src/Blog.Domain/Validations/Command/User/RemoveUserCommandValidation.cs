using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.Command.User;

public class RemoveUserCommandValidation : UserCommandValidation<RemoveUserCommand, bool>
{
    public RemoveUserCommandValidation()
    {
        ValidateId();
    }
}