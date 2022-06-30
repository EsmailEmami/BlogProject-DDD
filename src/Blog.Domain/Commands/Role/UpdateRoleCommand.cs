using Blog.Domain.Validations.Command.Role;

namespace Blog.Domain.Commands.Role;

public class UpdateRoleCommand : RoleCommand<Models.Role>
{
    public UpdateRoleCommand(Guid roleId, string roleName)
    {
        RoleId = roleId;
        RoleName = roleName;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateRoleCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}