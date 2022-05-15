using Blog.Domain.Validations.Query.User;

namespace Blog.Domain.Queries.User;

public class IsUserExistsQuery : UserQuery<bool>
{
    public IsUserExistsQuery(string email, string hashPassword)
    {
        Email = email;
        Password = hashPassword;
    }

    public override bool IsValid()
    {
        ValidationResult = new IsUserExistsQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}