using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Validations.Query.User;

public class GetUsersQueryValidation : UserQueryValidation<GetUsersQuery, List<UserForShowViewModel>>
{
    public GetUsersQueryValidation()
    {
        ValidateSkip();
        ValidateTake();
    }
}