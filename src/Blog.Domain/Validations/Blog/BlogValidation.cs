using Blog.Domain.Commands.Blog;
using FluentValidation;

namespace Blog.Domain.Validations.Blog;

public abstract class BlogValidation<T> : AbstractValidator<T> where T : BlogCommand
{
    protected void ValidateTitle()
    {
        RuleFor(c => c.BlogTitle)
            .NotEmpty().WithMessage("Please ensure you have entered the Name")
            .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
    }

    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}