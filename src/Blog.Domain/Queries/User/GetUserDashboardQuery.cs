using Blog.Domain.Validations.Query.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Queries.User;

public class GetUserDashboardQuery : UserQuery<DashboardViewModel>
{
    public GetUserDashboardQuery(Guid userId)
    {
        UserId = userId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetUserDashboardQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}