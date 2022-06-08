using Blog.Domain.Queries.UserRole;
using FluentValidation;

namespace Blog.Domain.Validations.Query.UserRole;

public abstract class UserRoleQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : UserRoleQuery<TResult>
{
    protected void ValidateUserId()
    {
        RuleFor(c => c.UserId)
            .NotEqual(Guid.Empty);
    }
}