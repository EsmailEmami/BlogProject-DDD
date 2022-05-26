using Blog.Domain.Queries.BlogTag;
using FluentValidation;

namespace Blog.Domain.Validations.Query.BlogTag;

public abstract class BlogTagQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : BlogTagQuery<TResult>
{
    protected void ValidateBlogId()
    {
        RuleFor(c => c.BlogId)
            .NotEqual(Guid.Empty);
    }
    protected void ValidateTagId()
    {
        RuleFor(c => c.TagId)
            .NotEqual(Guid.Empty);
    }
}