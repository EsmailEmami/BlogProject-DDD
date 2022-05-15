using Blog.Domain.Queries.User;

namespace Blog.Domain.Validations.Query.User;

public class IsUserExistsQueryValidation : UserQueryValidation<IsUserExistsQuery, bool>
{
    public IsUserExistsQueryValidation()
    {
        ValidateEmail();
        ValidatePassword();
    }
}