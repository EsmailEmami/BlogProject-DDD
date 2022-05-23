using Blog.Domain.Commands.Category;
using FluentValidation;

namespace Blog.Domain.Validations.Command.Category;

public abstract class CategoryCommandValidation<TCommand, TResult> : AbstractValidator<TCommand> where TCommand : CategoryCommand<TResult>
{
    protected void ValidateTitle()
    {
        RuleFor(c => c.CategoryTitle)
            .NotEmpty().WithMessage("لطفا عنوان دسته بندی را وارد کنید")
            .Length(3, 20).WithMessage("عنوان دسته بندی وارد شده باید بین 3 تا 20 کاراکتر باشد");
    }

    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}