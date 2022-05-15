using Blog.Domain.Validations.Query.User;

namespace Blog.Domain.Queries.User;

public class GetUserByEmailQuery : UserQuery<Models.User>
{
    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetUserByEmailQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}