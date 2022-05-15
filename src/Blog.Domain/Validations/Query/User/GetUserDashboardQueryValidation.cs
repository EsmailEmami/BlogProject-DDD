using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Validations.Query.User;

public class GetUserDashboardQueryValidation :
    UserQueryValidation<GetUserDashboardQuery, DashboardViewModel>
{
    public GetUserDashboardQueryValidation()
    {
        ValidateId();
    }
}