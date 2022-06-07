using Blog.Domain.Validations.Command.User;

namespace Blog.Domain.Commands.User;

public class UpdateUserPasswordCommand : UserCommand<bool>
{
    public UpdateUserPasswordCommand(Guid userId, string currentPassword, string newPassword, string confirmNewPassword)
    {
        Id = userId;
        CurrentPassword = currentPassword;
        Password = newPassword;
        ConfirmPassword = confirmNewPassword;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateUserPasswordCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}