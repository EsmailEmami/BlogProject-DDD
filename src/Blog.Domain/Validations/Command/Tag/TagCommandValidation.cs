using Blog.Domain.Commands.Comment;
using Blog.Domain.Commands.Tag;
using FluentValidation;

namespace Blog.Domain.Validations.Command.Tag;

public abstract class TagCommandValidation<TCommand, TResult> : AbstractValidator<TCommand> 
    where TCommand : TagCommand<TResult>
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