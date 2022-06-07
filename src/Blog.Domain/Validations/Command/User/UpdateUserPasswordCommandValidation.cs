using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.Command.User;

public class UpdateUserPasswordCommandValidation : UserCommandValidation<UpdateUserPasswordCommand, bool>
{
    public UpdateUserPasswordCommandValidation()
    {
        ValidateId();
        ValidateCurrentPassword();
        ValidatePassword();
    }
}