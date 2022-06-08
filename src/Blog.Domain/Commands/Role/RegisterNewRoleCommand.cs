using Blog.Domain.Validations.Command.Role;

namespace Blog.Domain.Commands.Role;

public class RegisterNewRoleCommand : RoleCommand<Guid>
{
    public RegisterNewRoleCommand(string roleName)
    {
        RoleName = roleName;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewRoleCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}