using Blog.Domain.Commands.BlogCategory;
using FluentValidation;

namespace Blog.Domain.Validations.Command.BlogCategory;

public abstract class BlogCategoryCommandValidation<TCommand, TResult> : AbstractValidator<TCommand> where TCommand : BlogCategoryCommand<TResult>
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
    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}