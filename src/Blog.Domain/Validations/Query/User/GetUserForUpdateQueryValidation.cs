using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Validations.Query.User;

public class GetUserForUpdateQueryValidation : UserQueryValidation<GetUserForUpdateQuery, UpdateUserViewModel>
{
    public GetUserForUpdateQueryValidation()
    {
        ValidateId();
    }
}