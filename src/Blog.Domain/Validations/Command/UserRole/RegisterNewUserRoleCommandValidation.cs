using Blog.Domain.Commands.UserRole;

namespace Blog.Domain.Validations.Command.UserRole;

public class RegisterNewUserRoleCommandValidation : UserRoleCommandValidation<RegisterNewUserRoleCommand>
{
    public RegisterNewUserRoleCommandValidation()
    {
        ValidateUserId();
        ValidateRoleId();
    }
}