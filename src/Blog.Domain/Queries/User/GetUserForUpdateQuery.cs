using Blog.Domain.Validations.Query.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Queries.User;

public class GetUserForUpdateQuery : UserQuery<UpdateUserViewModel>
{
    public GetUserForUpdateQuery(Guid userId)
    {
        UserId = userId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetUserForUpdateQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}