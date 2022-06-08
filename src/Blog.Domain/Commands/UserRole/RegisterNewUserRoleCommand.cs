using Blog.Domain.Validations.Command.UserRole;

namespace Blog.Domain.Commands.UserRole;

public class RegisterNewUserRoleCommand : UserRoleCommand
{
    public RegisterNewUserRoleCommand(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewUserRoleCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}