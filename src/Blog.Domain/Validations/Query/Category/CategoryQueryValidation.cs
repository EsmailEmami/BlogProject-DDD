using Blog.Domain.Queries.Category;
using FluentValidation;

namespace Blog.Domain.Validations.Query.Category;

public abstract class CategoryQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : CategoryQuery<TResult>
{
    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}