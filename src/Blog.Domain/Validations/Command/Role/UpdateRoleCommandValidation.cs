using Blog.Domain.Commands.Role;

namespace Blog.Domain.Validations.Command.Role;

public class UpdateRoleCommandValidation : RoleCommandValidation<UpdateRoleCommand, Models.Role>
{
    public UpdateRoleCommandValidation()
    {
        ValidateId();
        ValidateRoleName();
    }
}