using Blog.Domain.Queries.Role;
using Blog.Domain.ViewModels.Role;

namespace Blog.Domain.Validations.Query.Role;

public class GetRoleForUpdateQueryValidation : RoleQueryValidation<GetRoleForUpdateQuery, UpdateRoleViewModel>
{
    public GetRoleForUpdateQueryValidation()
    {
        ValidateId();
    }
}