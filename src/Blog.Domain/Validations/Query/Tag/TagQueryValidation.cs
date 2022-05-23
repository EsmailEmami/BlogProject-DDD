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

    protected void ValidateTagName()
    {
        RuleFor(c => c.TagName)
            .NotEmpty().WithMessage("لطفا نام تگ را وارد کنید")
            .Length(3, 20).WithMessage("نام تگ وارد شده باید بین 3 تا 10 کاراکتر باشد");

    }
}