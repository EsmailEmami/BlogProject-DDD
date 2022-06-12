using Blog.Domain.Queries.Tag;
using FluentValidation;

namespace Blog.Domain.Validations.Query.Tag;

public abstract class TagQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : TagQuery<TResult>
{
    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }

    protected void ValidateBlogId()
    {
        RuleFor(c => c.BlogId)
            .NotEqual(Guid.Empty);
    }
}