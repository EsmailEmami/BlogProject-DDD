using Blog.Domain.Validations.Query.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Domain.Queries.User;

public class GetAdminsQuery : UserQuery<List<UserForShowViewModel>>
{
    public GetAdminsQuery(int skip, int take, string? search)
    {
        Skip = skip;
        Take = take;
        Search = search;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetAdminsQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}