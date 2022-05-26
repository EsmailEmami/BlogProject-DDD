using Blog.Domain.Queries.BlogCategory;
using FluentValidation;

namespace Blog.Domain.Validations.Query.BlogCategory;

public abstract class BlogCategoryQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : BlogCategoryQuery<TResult>
{
    protected void ValidateBlogId()
    {
        RuleFor(c => c.BlogId)
            .NotEqual(Guid.Empty);
    }

    protected void ValidateCategoryId()
    {
        RuleFor(c => c.CategoryId)
            .NotEqual(Guid.Empty);
    }
}