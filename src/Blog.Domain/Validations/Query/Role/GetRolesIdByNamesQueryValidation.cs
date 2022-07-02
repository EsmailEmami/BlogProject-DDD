using Blog.Domain.Queries.Role;

namespace Blog.Domain.Validations.Query.Role;

public class GetRolesIdByNamesQueryValidation : RoleQueryValidation<GetRolesIdByNamesQuery, List<Guid>>
{
    public GetRolesIdByNamesQueryValidation()
    {
        ValidateNames();
    }
}