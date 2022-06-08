using Blog.Domain.Queries.UserRole;

namespace Blog.Domain.Validations.Query.UserRole;

public class GetAllUserRolesIdQueryValidation : UserRoleQueryValidation<GetAllUserRolesIdQuery, List<Guid>>
{
    public GetAllUserRolesIdQueryValidation()
    {
        ValidateUserId();
    }
}