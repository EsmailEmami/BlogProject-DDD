using Blog.Domain.Validations.Query.UserRole;

namespace Blog.Domain.Queries.UserRole;

public class GetAllUserRolesIdQuery : UserRoleQuery<List<Guid>>
{
    public GetAllUserRolesIdQuery(Guid userId)
    {
        UserId = userId;
    }
    public override bool IsValid()
    {
        ValidationResult = new GetAllUserRolesIdQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}