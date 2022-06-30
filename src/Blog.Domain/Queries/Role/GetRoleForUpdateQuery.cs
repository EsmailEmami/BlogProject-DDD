using Blog.Domain.Validations.Query.Role;
using Blog.Domain.ViewModels.Role;

namespace Blog.Domain.Queries.Role;

public class GetRoleForUpdateQuery : RoleQuery<UpdateRoleViewModel>
{
    public GetRoleForUpdateQuery(Guid roleId)
    {
        RoleId = roleId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetRoleForUpdateQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}