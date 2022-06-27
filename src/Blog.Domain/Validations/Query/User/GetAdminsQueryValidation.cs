using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Validations.Query.User;

public class GetAdminsQueryValidation : UserQueryValidation<GetAdminsQuery, List<UserForShowViewModel>>
{
    public GetAdminsQueryValidation()
    {
        ValidateSkip();
        ValidateTake();
    }
}