using Blog.Domain.Queries.User;

namespace Blog.Domain.Validations.Query.User;

public class GetUserByEmailQueryValidation : UserQueryValidation<GetUserByEmailQuery, Models.User>
{
    public GetUserByEmailQueryValidation()
    {
        ValidateEmail();
    }
}