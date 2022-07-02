using Blog.Domain.Validations.Query.Role;

namespace Blog.Domain.Queries.Role;

public class GetRolesIdByNamesQuery : RoleQuery<List<Guid>>
{
    public GetRolesIdByNamesQuery(List<string> rolesName)
    {
        Names = rolesName;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetRolesIdByNamesQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}