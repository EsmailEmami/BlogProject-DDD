using Blog.Domain.Validations.Query.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Queries.User;

public class GetUsersQuery : UserQuery<List<UserForShowViewModel>>
{
    public GetUsersQuery(int skip, int take, string? search)
    {
        Skip = skip;
        Take = take;
        Search = search;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetUsersQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}