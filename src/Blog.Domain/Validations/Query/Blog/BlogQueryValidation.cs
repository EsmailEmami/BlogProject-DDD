using Blog.Domain.Queries.Blog;
using FluentValidation;

namespace Blog.Domain.Validations.Query.Blog;

public abstract class BlogQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : BlogQuery<TResult>
{
    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty).WithMessage("لطفا آیدی مقاله را وارد کنید");
    }
}