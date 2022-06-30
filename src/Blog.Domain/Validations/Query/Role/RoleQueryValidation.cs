using Blog.Domain.Queries.Role;
using FluentValidation;

namespace Blog.Domain.Validations.Query.Role;

public abstract class RoleQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : RoleQuery<TResult>
{
    protected void ValidateId()
    {
        RuleFor(c => c.RoleId)
            .NotEqual(Guid.Empty);
    }
}