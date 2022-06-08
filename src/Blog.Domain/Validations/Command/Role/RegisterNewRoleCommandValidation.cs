using Blog.Domain.Commands.Role;

namespace Blog.Domain.Validations.Command.Role;

public class RegisterNewRoleCommandValidation : RoleCommandValidation<RegisterNewRoleCommand, Guid>
{
    public RegisterNewRoleCommandValidation()
    {
        ValidateRoleName();
    }
}